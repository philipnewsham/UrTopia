using UnityEngine;
using System.Collections;

public class OnClickFollowMouse : MonoBehaviour 
{
	public bool shield;
	private bool m_shield {get{ return shield;}}
	private bool m_clickedOn;
	private Rigidbody m_rigidbody;

	void Start()
	{
		m_rigidbody = GetComponent<Rigidbody> ();
	}

	void OnEnable()
	{
		m_rigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate()
	{
		if (m_clickedOn) {
			Vector3 position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			transform.position = new Vector3(position.x,position.y,0f);
		}
	}
	void OnMouseDown()
	{
		if (!m_shield) {
			m_rigidbody.velocity = new Vector3 (0f, 0f, 0f);
			m_clickedOn = true;
		} else {
			shield = false;
		}
	}

	public void OnMouseUp()
	{
		m_clickedOn = false;
	}
}
