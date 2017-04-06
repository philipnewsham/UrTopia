using UnityEngine;
using System.Collections;

public class FadeOverLifetime : MonoBehaviour {

	private Transform m_transform;
	private float m_speed = 0.625f;
	// Use this for initialization
	void Start () {
		m_transform = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_transform.localScale = new Vector3(m_transform.localScale.x - m_speed * Time.deltaTime, m_transform.localScale.y - m_speed * Time.deltaTime, m_transform.localScale.z - m_speed * Time.deltaTime);
	}
}
