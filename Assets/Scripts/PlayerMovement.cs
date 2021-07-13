using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    // Start is called before the first frame update
    float xRot = 0f;
    float yRot = 0f;
    [SerializeField] Transform cameraTransform;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftAlt))
            Cursor.lockState = CursorLockMode.Locked; 
        if(Input.GetKeyUp(KeyCode.LeftAlt))
            Cursor.lockState = CursorLockMode.None;
        if(Input.GetKey(KeyCode.LeftAlt))
        {
            transform.rotation = Quaternion.AngleAxis(yRot , Vector3.up); 
            yRot += Input.GetAxis("Mouse X");
            cameraTransform.localRotation =  Quaternion.AngleAxis(xRot , -Vector3.right); 
            xRot += Input.GetAxis("Mouse Y");
            xRot = Mathf.Clamp(xRot , -90 , 90);
        }
    }
}

