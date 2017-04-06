using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyController : MonoBehaviour 
{
	private float m_time;
	public float waveTime;
	private float m_waveTime{get{return waveTime;}}
	public GameObject[] enemies;
	private int m_waveNo = 1;

	private List<int> m_enemyNo = new List<int>();
	//0 = meteor, 1 = Nuke, 2 = Clouds, 3 = UFO

	private Vector3 m_meteorAimPosition;
	private Vector3 m_meteorPosition;
	private Vector3 m_ufoPosition;

	private float m_minTime;
	private float m_maxTime;

	private bool m_spawnEnemy;
	private bool m_gamePlaying = false;

	void Start()
	{

	}

	public void StartGame()
	{
		m_gamePlaying = true;
		m_time = 0f;
		Wave (1);
	}
	void Update()
	{
		if (m_gamePlaying) {
			m_time += Time.deltaTime;

			waveTime -= Time.deltaTime;
			if (waveTime < 0) {
				waveTime = 15f;
				m_spawnEnemy = false;
				m_waveNo += 1;
				Wave (m_waveNo);
			}
		}
	}

	public void StopCoroutines()
	{
		StopAllCoroutines ();
		m_gamePlaying = false;
		m_time = 0f;
	}

	void Wave(int waveNo)
	{
		StopAllCoroutines ();
		m_enemyNo.Clear ();
		if (waveNo == 1) {
			m_enemyNo.Add (0);
			m_minTime = 1f;
			m_maxTime = 1.5f;
		} else if (waveNo == 2) {
			m_enemyNo.Add (0);
			m_enemyNo.Add (0);
			m_enemyNo.Add (1);
			m_enemyNo.Add (1);
			m_enemyNo.Add (2);
			m_minTime = 1f;
			m_maxTime = 1.5f;
		} else if (waveNo == 3) {
			m_enemyNo.Add (0);
			m_enemyNo.Add (1);
			m_enemyNo.Add (2);
			m_minTime = .5f;
			m_maxTime = 1f;
		} else if (waveNo > 3) {
			m_enemyNo.Add (0);
			m_enemyNo.Add (1);
			m_enemyNo.Add (2);
			m_minTime = .25f;
			m_maxTime = .75f;
		}
		m_spawnEnemy = true;
		StartCoroutine (SpawnEnemies ());
	}

	IEnumerator SpawnEnemies()
	{
		while (m_spawnEnemy) {
			int currentEnemy = m_enemyNo[Random.Range (0, m_enemyNo.Count)];

			if (currentEnemy == 0) {
				InstantiateMeteor ();
			} else if (currentEnemy == 1) {
				InstantiateMeteor ();
			} else if (currentEnemy == 2) {
				//InstantiateCloud();
			} else if (currentEnemy == 3) {
				InstantiateUFO();
			}

			yield return new WaitForSeconds (Random.Range (m_minTime, m_maxTime));
		}
	}

	void InstantiateMeteor()
	{
		float force = 10f;

		int choseSide = Random.Range (0, 4);
		//0 - top, 1 - bottom, 2 - left, 3 - right


		if (choseSide == 0) 
		{
			m_meteorAimPosition = new Vector3 (Random.Range (-10f, 10f), -6f, 0f);
			m_meteorPosition = new Vector3 (Random.Range (-10f, 10f), 6f, 0f);
		}else if (choseSide == 1) 
		{
			m_meteorAimPosition = new Vector3 (Random.Range (-10f, 10f), 6f, 0f);
			m_meteorPosition = new Vector3 (Random.Range (-10f, 10f), -6f, 0f);
		} else if (choseSide == 2) 
		{
			m_meteorAimPosition = new Vector3 (-12f, Random.Range (-6f, 6f), 0f);
			m_meteorPosition = new Vector3 (12f, Random.Range (-6f, 6f), 0f);
		} else if (choseSide == 3) 
		{
			m_meteorAimPosition = new Vector3 (12f, Random.Range (-6f, 6f), 0f);
			m_meteorPosition = new Vector3 (-12f, Random.Range (-10f, 10f), 0f);
		}

		GameObject meteorClone = Instantiate (enemies[0], m_meteorPosition, Quaternion.identity) as GameObject;
		Vector3 direction = meteorClone.GetComponent<Transform> ().position - m_meteorAimPosition;
		meteorClone.GetComponent<Rigidbody> ().AddForce (-direction * (force + (0.002f * m_time)));
	}

	void InstantiateRocket()
	{
		float force = 10f;

		int choseSide = Random.Range (0, 4);
		//0 - top, 1 - bottom, 2 - left, 3 - right


		if (choseSide == 0) 
		{
			m_meteorAimPosition = new Vector3 (Random.Range (-10f, 10f), -6f, 0f);
			m_meteorPosition = new Vector3 (Random.Range (-10f, 10f), 6f, 0f);
		}else if (choseSide == 1) 
		{
			m_meteorAimPosition = new Vector3 (Random.Range (-10f, 10f), 6f, 0f);
			m_meteorPosition = new Vector3 (Random.Range (-10f, 10f), -6f, 0f);
		} else if (choseSide == 2) 
		{
			m_meteorAimPosition = new Vector3 (-12f, Random.Range (-6f, 6f), 0f);
			m_meteorPosition = new Vector3 (12f, Random.Range (-6f, 6f), 0f);
		} else if (choseSide == 3) 
		{
			m_meteorAimPosition = new Vector3 (12f, Random.Range (-6f, 6f), 0f);
			m_meteorPosition = new Vector3 (-12f, Random.Range (-10f, 10f), 0f);
		}

		GameObject meteorClone = Instantiate (enemies[1], m_meteorPosition, Quaternion.identity) as GameObject;
		Vector3 direction = meteorClone.GetComponent<Transform> ().position - m_meteorAimPosition;
		meteorClone.transform.LookAt(m_meteorAimPosition);
		meteorClone.GetComponent<Rigidbody> ().AddForce (-direction * ((force * 1.2f) + (0.002f * m_time)));
	}

	void InstantiateUFO()
	{
		int chooseSide = Random.Range (0, 2);
		//0 - left, 1 - right
		if (chooseSide == 0) {
			m_ufoPosition = new Vector3 (-12f, Random.Range (-6, 6), 0f);
		} else if (chooseSide == 1) {
			m_ufoPosition = new Vector3 (-12f, Random.Range (-6, 6), 0f);
		}
		GameObject ufoClone = Instantiate (enemies [2], m_ufoPosition, Quaternion.identity) as GameObject;
	}
}
