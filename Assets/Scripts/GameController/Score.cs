using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour 
{
	public Button screenWipeButton;
	private ScreenWiper m_screenWiperScript;

	public Button droneButton;
	private SpawnDrone m_droneScript;

	public Button shieldButton;
	private GirderSpawn m_shieldScript;

	public float powerUpScoreBonus;
	private float m_pointsToPowerUp;
	private float m_scoreBase = 100f;
	private float m_scoreMultiplier;
	private GameObject m_planet;
	private PlanetHP m_planetHPScript;
	private float m_powerUpScore;
	[SerializeField]
	private float m_scoreFinal;
	private bool m_gamePlaying = false;
	public GameObject nearMissText;
	public Text scoreText; 

	void Start()
	{
		m_planet = GameObject.FindGameObjectWithTag ("Planet");
		m_planetHPScript = m_planet.GetComponent<PlanetHP> ();
		//m_pointsToPowerUp = powerUpScoreBonus;
		m_screenWiperScript = screenWipeButton.GetComponent<ScreenWiper> ();
		m_droneScript = droneButton.GetComponent<SpawnDrone> ();
		m_shieldScript = shieldButton.GetComponent<GirderSpawn> ();
	}

	public void ResetScore()
	{
		m_scoreFinal = 0f;
		m_pointsToPowerUp = 0f;
		scoreText.text = "Score: " + Mathf.Floor (m_scoreFinal);
		m_gamePlaying = true;
	}
	void Update()
	{
		if (m_gamePlaying) {
			m_scoreFinal += (m_scoreBase * Time.deltaTime) * m_scoreMultiplier;
			m_pointsToPowerUp += (m_scoreBase * Time.deltaTime) * m_scoreMultiplier;

			//check if reached threashold for upgrade
			if (m_pointsToPowerUp > powerUpScoreBonus) {
				GivePowerUp ();
				m_pointsToPowerUp = 0f;
			}

			scoreText.text = "Score: " + Mathf.Floor (m_scoreFinal);
		}
	}

	public void ScoreMultiplier(float hp)
	{
		if (hp > 0)
			m_scoreMultiplier = hp * 0.2f;
	}

	public void BonusScore(float score, string type)
	{
		m_scoreFinal += score;
		if (type == "NearMiss") {
			nearMissText.SetActive (true);
		}
	}

	void GivePowerUp()
	{
		print ("Power up!");
		int powerSelect = Random.Range (0, 3);
		if (powerSelect == 0) {
			m_screenWiperScript.AddScreenWipe ();
		} else if (powerSelect == 1) {
			m_droneScript.AddDrone ();
		} else if (powerSelect == 2) {
			m_shieldScript.AddShield ();
		}
	}

	public void EndGame()
	{
		m_gamePlaying = false;
		//if(m_scoreFinal - m_highScore < 0)
		//{
		//m_highScore = m_scoreFinal;
		//}
		//save();
	}
}
