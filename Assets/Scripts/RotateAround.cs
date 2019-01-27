using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour {

    public GameObject RotatePoint;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        transform.LookAt(RotatePoint.transform.position);
        transform.Translate(Vector3.right * Time.deltaTime);
        
	}
}
