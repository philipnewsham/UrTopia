using UnityEngine;
using System.Collections;

public class rotateObject : MonoBehaviour {

    public float turnSpeed;


	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
	
	}
}
