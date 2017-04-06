using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour {

	public Slider healthSlider;
	public GameObject handle;
	public GameObject planet;
	private PlanetHP m_planetHPScript;
	public Sprite[] faces = new Sprite[4];
	private float m_maxNo;
	private Sprite m_currentSprite;
	public byte[] colour01;
	public byte[] colour02;
	public byte[] colour03;
	public byte[] colour04;
	public GameObject background;
	//private Color m_currentColour;
	// Use this for initialization
	void Start () 
	{
		m_planetHPScript = planet.GetComponent<PlanetHP> ();
		healthSlider.minValue = 0f;
		healthSlider.maxValue = m_planetHPScript.health;
		m_maxNo = healthSlider.maxValue;
		m_currentSprite = faces [0];
		handle.GetComponent<Image>().sprite = m_currentSprite;
		background.GetComponent<Image> ().color = new Color32 (colour01 [0], colour01 [1], colour01 [2], colour01 [3]);

	}

	public void SliderRestart()
	{
		healthSlider.maxValue = m_planetHPScript.health;
		m_maxNo = healthSlider.maxValue;
	}
	
	// Update is called once per frame
	void Update () 
	{
		healthSlider.value = m_planetHPScript.health; 

		if (healthSlider.value > ((m_maxNo / 4) * 3)) {
			m_currentSprite = faces [0];
			background.GetComponent<Image> ().color = new Color32 (colour01 [0], colour01 [1], colour01 [2], colour01 [3]);
		}else if(healthSlider.value > ((m_maxNo/4)*2))
			{
				m_currentSprite = faces[1];
			background.GetComponent<Image> ().color = new Color32 (colour02 [0], colour02 [1], colour02 [2], colour02 [3]);
			}else if(healthSlider.value > ((m_maxNo/4)*1))
				{
					m_currentSprite = faces[2];
			background.GetComponent<Image> ().color = new Color32 (colour03 [0], colour03 [1], colour03 [2], colour03 [3]);
				}else
					{
						m_currentSprite = faces[3];
			background.GetComponent<Image> ().color = new Color32 (colour04 [0], colour04 [1], colour04 [2], colour04 [3]);
					}
		handle.GetComponent<Image>().sprite = m_currentSprite;
	}
}
