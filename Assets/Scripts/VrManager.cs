using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;
using Google.XR.Cardboard;
public class VrManager : MonoBehaviour
{
    public static bool isVrMode = false;
    private bool _isVrModeEnabled
    {
        get
        {
            return XRGeneralSettings.Instance.Manager.isInitializationComplete;
        }
    }
    public void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.brightness = 1.0f;
        if(isVrMode)
            EnterVR();
    }
    public void Enter()
    {
        if(isVrMode)
            EnterVR();
        else
            ExitVR();
    }
    public void DisableSplitScreen()
    {
        isVrMode = false;
    }
    public void EnableSplitScreen()
    {
        isVrMode = true;
    }

    public void EnterVR()
    {
        StartCoroutine(StartXR());
    }

    public void ExitVR()
    {
        StopXR();
    }
    private IEnumerator StartXR()
    {
        Debug.Log("Initializing XR...");
        yield return XRGeneralSettings.Instance.Manager.InitializeLoader();

        if (XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            Debug.LogError("Initializing XR Failed.");
        }
        else
        {
            Debug.Log("XR initialized.");

            Debug.Log("Starting XR...");
            XRGeneralSettings.Instance.Manager.StartSubsystems();
            Debug.Log("XR started.");
        }
    }

    private void StopXR()
    {
        Debug.Log("Stopping XR...");
        Debug.Log(XRGeneralSettings.Instance);
        XRGeneralSettings.Instance.Manager.StopSubsystems();
        Debug.Log("XR stopped.");

        Debug.Log("Deinitializing XR...");
        XRGeneralSettings.Instance.Manager.DeinitializeLoader();
        Debug.Log("XR deinitialized.");
    }
    public void VrModeSwitch()
    {
        if(Player.VrMode == 1)
        {
            Player.VrMode = 2;
            Player.PlayerPosition = Player.instance.transform.position;
            SceneManagerScript.Instance.LoadScene(2);
        }
        else
        {
            SceneManagerScript.Instance.LoadScene(1);
            Player.VrMode = 1;
        }
    }
}
