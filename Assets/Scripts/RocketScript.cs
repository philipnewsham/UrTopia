using UnityEngine;
using System.Collections;

public class RocketScript : MonoBehaviour {
	private Vector3 m_direction;
	private float m_force = 100f;
	// Use this for initialization
	void Start () {
		m_direction = Vector3.forward;
		gameObject.GetComponent<Rigidbody> ().AddRelativeForce (m_direction * m_force);
		Invoke ("Return", 2);
	}
	
	void Return()
	{
		gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
		transform.LookAt(GameObject.FindGameObjectWithTag("Planet").GetComponent<Transform>());
		gameObject.GetComponent<Rigidbody> ().AddRelativeForce (m_direction * (m_force * 1.2f));
	}
}
