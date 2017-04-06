using UnityEngine;
using System.Collections;

public class PlanetRotate : MonoBehaviour {

	public float spinSpeed = 5f;
	private bool m_turning = true;
	private float m_rotY;

	void Start()
	{
		m_rotY = 0f;
		//InvokeRepeating ("RandomlyStop", 3, 3);
	}

	void FixedUpdate () 
	{
		if (m_turning) {
			m_rotY = m_rotY + spinSpeed * Time.deltaTime;
			gameObject.transform.eulerAngles = new Vector3 (0, m_rotY, 0);
		} 
		else 
		{
			float aimRot = transform.eulerAngles.y + 5f;
			m_rotY = Mathf.Lerp (transform.eulerAngles.y, aimRot, Time.deltaTime);
		}
		gameObject.transform.eulerAngles = new Vector3 (0, m_rotY, 0);
	}

	void RandomlyStop()
	{
		int checkNumber = Random.Range (0, 11);
		if (checkNumber == 10) 
		{
			m_turning = false;
		}
	}
}
