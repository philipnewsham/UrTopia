using UnityEngine;
using System.Collections;

public class UFO : MonoBehaviour 
{
	public float damage = 0.3f;
	public float speed;
	private int m_ufoHealth = 2;
	private float m_posX;
	private GameObject m_planet;
	private PlanetHP m_planetHPScript;
	private bool m_attacking;
	private OnClickFollowMouse m_followMouseScript;
	private float m_posY;
	private bool m_canAttack = true;
	private bool m_hasAttacked = false;
	void Start()
	{
		m_planet = GameObject.FindGameObjectWithTag ("Planet");
		m_planetHPScript = m_planet.GetComponent<PlanetHP> ();
		m_followMouseScript = gameObject.GetComponent<OnClickFollowMouse> ();
		m_posY = transform.position.y;
	}

	void Update()
	{
		if ((!m_attacking)) 
		{
			m_posX = transform.position.x + speed * Time.deltaTime;
			transform.position = new Vector3 (m_posX, transform.position.y, 0f);	
		}
			
	}

	void AttackPlanet()
	{
		m_planetHPScript.ConstantDamage (1, 0.03f);
		m_hasAttacked = true;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if((other.gameObject.tag == "Planet")&&(!m_attacking)&&(m_canAttack))
		{
			m_attacking = true;
			m_canAttack = false;
			AttackPlanet ();
		}
}

	void OnMouseDown()
	{
			Destroy ();
			m_followMouseScript.enabled = true;
	}

	void Destroy()
	{
		m_canAttack = false;
		if (m_hasAttacked) {
			m_planetHPScript.ConstantDamage (-1, -0.03f);
		}
	}
}