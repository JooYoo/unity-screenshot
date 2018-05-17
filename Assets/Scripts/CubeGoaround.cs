using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGoaround : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	    this.gameObject.transform.Rotate(new Vector3(0,25,0) * Time.deltaTime);	
	}
}
