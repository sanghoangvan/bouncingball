using UnityEngine;
using System.Collections;
using System;
public class Wrap2D : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(transform.position.x>=3.45f)
        {
            transform.position = new Vector3(-3.45f, transform.position.y, transform.position.z);
        }
        else if(transform.position.x<=-3.45f)
        {
            transform.position = new Vector3(3.45f, transform.position.y, transform.position.z);
        }
	}
    void Update()
    {
      
    }
}
