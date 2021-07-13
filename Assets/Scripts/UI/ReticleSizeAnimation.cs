using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleSizeAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject reticle;
    public AnimationCurve curve;
    public float AnimationDuration = .2f;
    bool gaze;
    public float SizeMultiplier = 1.8f;

    void Start()
    {
        gaze = CameraPointer.instance.getGazedAt();
    }

    // Update is called once per frame
    void Update()
    {
        bool change = CameraPointer.instance.getGazedAt();
        if(gaze != change)
        {
            gaze =change; 
            if(gaze)
                reticle.LeanScale(Vector3.one*SizeMultiplier ,AnimationDuration ).setEaseOutQuad();
            else
                reticle.LeanScale(Vector3.one ,AnimationDuration ).setEaseInQuad();
        }
     
    }
}
