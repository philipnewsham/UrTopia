using UnityEngine;
using System.Collections;

public class MouseSwipe : MonoBehaviour {
	public float force = 100f;
	public float marginOfError = 0.2f;
	private Vector3 m_mouseBegin;
	private Vector3 m_mouseEnd;
	private bool m_hitObject;
	private Rigidbody m_selectedRb;


	private float h;
	private float v;

	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			m_mouseBegin = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast (ray, out hit)) 
			{
				if (hit.rigidbody != null) 
				{	
					m_selectedRb = hit.rigidbody;
					m_hitObject = true;
				}
			} 
			else 
			{
				m_hitObject = false;
			}
		}

		if (Input.GetMouseButtonUp (0)) 
		{

			m_mouseEnd = Camera.main.ScreenToWorldPoint (Input.mousePosition);

			if(m_hitObject)
				MouseSwiping (m_mouseBegin, m_mouseEnd);
			
			m_hitObject = false;
		}

		if (Input.GetMouseButton (0) && m_hitObject) {
			if ((Input.GetAxisRaw ("Mouse X") < marginOfError && Input.GetAxisRaw ("Mouse X") > -marginOfError) || (Input.GetAxisRaw ("Mouse Y") < marginOfError && Input.GetAxisRaw ("Mouse Y") > -marginOfError)) 
			{
				m_mouseBegin = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			}
		}
	}

	void MouseSwiping(Vector3 mouseBegin, Vector3 mouseEnd)
	{
		Vector3 direction = mouseEnd - mouseBegin;
		m_selectedRb.AddForce (direction * force);
	}
}