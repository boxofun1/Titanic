using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleCamera : MonoBehaviour
{
    Camera topCamera;
    bool displayCamera;
    // Start is called before the first frame update
    void Start()
    {
        topCamera = GetComponent<Camera>();
        displayCamera = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
		{
            displayCamera = !displayCamera;
            if (displayCamera) topCamera.enabled = true;
            else topCamera.enabled = false;
		}
    }
}
