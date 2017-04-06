using UnityEngine;
using System.Collections;

public class Meteorite : MonoBehaviour 
{
	public GameObject meteor;
	public float force;
	void Start()
	{
		InvokeRepeating ("InstantiateMeteor", 3, 3);
	}

	void InstantiateMeteor()
	{
		Vector3 aimPosition = new Vector3 (Random.Range (-10f, 10f), -transform.position.y, 0f);
		Vector3 position = new Vector3(Random.Range(-10f,10f),transform.position.y, 0f);
		GameObject clone = Instantiate (meteor, position, Quaternion.identity) as GameObject;
		Vector3 direction = clone.GetComponent<Transform> ().position - aimPosition;
		clone.GetComponent<Rigidbody> ().AddForce (-direction * force);
	}
}
