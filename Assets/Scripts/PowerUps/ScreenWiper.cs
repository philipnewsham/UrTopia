using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class ScreenWiper : MonoBehaviour 
{
	private List<GameObject> m_meteor = new List<GameObject>();
	private int m_screenWipes = 0;
	private Button m_wipeButton;
	public Text m_wipeButtonText;

	public Image buttonImage;
	public Sprite deactiveImage;
	public Sprite activeImage;
	//private List<GameObject> m_ufo = new List<GameObject>();

	void Start()
	{
		m_wipeButton = GetComponent<Button> ();
		//m_wipeButtonText = m_wipeButton.GetComponent<Text> ();
		WipeScreen ();
		m_wipeButtonText.text = "" + m_screenWipes;
	}

	public void WipeScreen()
	{
		if (m_screenWipes > 0) {
			m_screenWipes -= 1;
			m_meteor.Clear ();
			m_meteor.AddRange (GameObject.FindGameObjectsWithTag ("Meteor"));

			for (int i = 0; i < m_meteor.Count; i++) {
				if (m_meteor != null)
					m_meteor [i].GetComponent<SmashIntoPlanet> ().Explode ();
			}
		} else {
			m_wipeButton.interactable =  false;
			buttonImage.sprite = deactiveImage;
		}
		if (m_screenWipes == 0) {
			buttonImage.sprite = deactiveImage;
			m_wipeButton.interactable =  false;
		}
		m_wipeButtonText.text = "" + m_screenWipes;
	}

	public void AddScreenWipe()
	{
		m_screenWipes += 1;
		m_wipeButton.interactable = true;
		buttonImage.sprite = activeImage;
		m_wipeButtonText.text = "" + m_screenWipes;
	}

}
