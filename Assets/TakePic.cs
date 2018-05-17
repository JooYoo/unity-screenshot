using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePic : MonoBehaviour
{
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            ScreenShot.TakeScreenShot("/../Screenshots/Screenshot_", DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss"), Camera.main);
        }
		
	}
}
