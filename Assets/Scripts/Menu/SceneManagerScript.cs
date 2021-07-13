using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerScript : MonoBehaviour
{
    public Animator Transition;
    public Transform LoadingBarFill;
    public float TransitionTime = 1;
    float Progress = 0;
    AsyncOperation Loading;
    public static SceneManagerScript Instance;
    void Awake()
    {
        Transition.gameObject.GetComponent<Canvas>().worldCamera = Camera.main;
        Instance = this;
    }

    public int getSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
    public void LoadSceneDelta(int DeltaBuildIndex)
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex + DeltaBuildIndex);
    }
    public void LoadScene(int BuildIndex)
    {
        StartCoroutine(LoadSceneEnum(BuildIndex));
    }
    IEnumerator LoadSceneEnum(int BuildIndex)
    {
        LoadingBarFill.localScale = new Vector3(0f, 1f , 1f);
        Transition.SetTrigger("Start");
        yield return new WaitForSeconds(TransitionTime);

        Loading = SceneManager.LoadSceneAsync(BuildIndex);
        while(!Loading.isDone)
        {
            Progress = Loading.progress;
            Progress = Mathf.Clamp01(Progress);
            LoadingBarFill.localScale = new Vector3(Progress , 1f , 1f);
            Debug.Log(Progress);
            yield return null; 
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
