using UnityEngine;
using System.Collections;

public class HomingRocket : MonoBehaviour {
	

	public float fpsTargetDistance = 500f;
	public float enemyLookDistance = 500f;
	public float attackDistance = 500f;
	public float enemyMovementSpeed = 50f;
	public float damping = 5;
	private Transform fpsTarget;
	Rigidbody theRigidbody;
	Renderer myRender;

	private GameObject m_planet;

	// Use this for initialization
	void Start () {

		myRender = GetComponent<Renderer> ();
		theRigidbody = GetComponent<Rigidbody>();
		m_planet = GameObject.FindGameObjectWithTag ("Planet");
		fpsTarget = m_planet.GetComponent<Transform> ();
	}

	// Update is called once per frame
	void FixedUpdate () {

		fpsTargetDistance = Vector3.Distance (fpsTarget.position, transform.position );

		if (fpsTargetDistance > enemyLookDistance) 
		{
			
		}

		if (fpsTargetDistance < enemyLookDistance) 
		{
			lookAtPlayer ();
		} 

		if (fpsTargetDistance < attackDistance) 
		{
			attackPlease();
		}

	}
	void lookAtPlayer () {

		Quaternion rotation = Quaternion.LookRotation(fpsTarget.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);

	}

	void attackPlease () {

		theRigidbody.AddForce (transform.up * enemyMovementSpeed);

	}
}﻿