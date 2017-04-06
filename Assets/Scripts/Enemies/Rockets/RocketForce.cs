using UnityEngine;
using System.Collections;

public class RocketForce : MonoBehaviour {

	public float thrust;
	private Rigidbody m_rigidbody;
	public float waitInSeconds = 1.0f;
	public float startTime;
	private HomingRocket m_homingRocketScript;

	void Start() 
	{
		m_rigidbody = GetComponent<Rigidbody>();
		startTime = Time.time;
		m_homingRocketScript = GetComponent<HomingRocket>();
		Invoke ("ChangeScripts", 2f);
		m_rigidbody.AddForce (Vector3.up * thrust);
	}

	void FixedUpdate() 
	{
		Vector3 direction = new Vector3 (1, 0, 0);
		//m_rigidbody.AddForce (Vector3.up * thrust);
	}

	void ChangeScripts()
	{
		m_homingRocketScript.enabled = true;
	}
}
