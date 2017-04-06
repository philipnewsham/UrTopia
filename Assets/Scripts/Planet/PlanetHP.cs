using UnityEngine;
using System.Collections;

public class PlanetHP : MonoBehaviour 
{
	public float health = 2;
	private float m_maxDamage;
	private bool m_takingConstantDamage;
	private GameObject m_gameController;
	private Score m_scoreScript;
	private EnemyController m_enemyController;
	public GameObject restartButton;
	public GameObject[] uiElements;

	void Start()
	{
		m_gameController = GameObject.FindGameObjectWithTag ("GameController");
		m_scoreScript = m_gameController.GetComponent<Score> ();
		m_enemyController = m_gameController.GetComponent<EnemyController> ();
		m_scoreScript.ScoreMultiplier (health);
	}

	void Update()
	{
		if (m_takingConstantDamage) {
			health -= m_maxDamage * Time.deltaTime;
			m_scoreScript.ScoreMultiplier (health);

			health -= m_maxDamage;
			if (health <= 0) {
				GameOver ();
			} else {
				m_scoreScript.ScoreMultiplier (health);
				//Update Health
			}
		}
	}
	public void ConstantDamage(int enemies, float damage)
	{
		if (enemies != 0) {
			m_maxDamage += damage;
			m_takingConstantDamage = true;
		} else {
			m_maxDamage = 0;
			m_takingConstantDamage = false;
		}
	}

	public void LoseHealthHit(float damage)
	{
		health -= damage;
		if (health <= 0) {
			GameOver ();
		} else {
		m_scoreScript.ScoreMultiplier (health);
		//Update Health
		}
	}

	public void AddHealth(float healthBonus)
	{
		health += healthBonus;
	}

	void GameOver()
	{
		m_enemyController.StopCoroutines ();
		m_scoreScript.EndGame ();
		health = 10f;
		m_scoreScript.ScoreMultiplier (health);
		for (int i = 0; i < uiElements.Length; i++) {
			uiElements [i].SetActive (false);
		}

		restartButton.SetActive (true);
		print ("Game over");
	}
}
