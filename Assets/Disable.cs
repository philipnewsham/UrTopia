using UnityEngine;
using System.Collections;

public class Disable : MonoBehaviour {

	// Use this for initialization
	void OnEnable () 
	{
		Invoke ("TurnOff", 1);
	}
	
	void TurnOff()
	{
		gameObject.SetActive (false);
	}
}
