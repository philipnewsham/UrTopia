using UnityEngine;
using System.Collections;

public class SmashIntoPlanet : MonoBehaviour 
{
	private GameObject m_planet;
	private PlanetHP m_planetHPScript;
	public float damage = 1f;
	public GameObject[] pieces;
	public float radius = 50;
	public float power = 1000;
	public float lifetime = 1;

	void Start()
	{
		m_planet = GameObject.FindGameObjectWithTag ("Planet");
		m_planetHPScript = m_planet.GetComponent<PlanetHP> ();
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Planet") 
		{
			m_planetHPScript.LoseHealthHit (1f);
		}
		Explode ();
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Droid") 
		{
			Explode ();
		}
	}

	public void Explode()
	{
		GetComponent<MeshRenderer>().enabled = false;
		GetComponent<Collider> ().enabled = false;
		GetComponent<AudioSource> ().Play ();
		Destroy (gameObject, 0.5f);
		for (int i = 0; i < pieces.Length; i++) {
			GameObject clone = Instantiate (pieces [i], transform.position, Quaternion.identity) as GameObject;
			clone.GetComponent<Rigidbody>().AddExplosionForce(power * 10,clone.transform.position+Random.insideUnitSphere*radius,radius,3.0f);
			Destroy (clone.gameObject, 1f);
		}
	}
}
