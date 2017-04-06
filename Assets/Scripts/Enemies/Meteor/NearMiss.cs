using UnityEngine;
using System.Collections;

public class NearMiss : MonoBehaviour {
	private GameObject m_gameController;
	private Score m_scoreScript;
	private bool m_clickedOn;

	void OnMouseDown()
	{
		m_clickedOn = true;
	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Planet") {
			if (!m_clickedOn) {
				Debug.Log("Near Miss! +1000 points!");
				m_gameController = GameObject.FindGameObjectWithTag ("GameController");
				m_scoreScript = m_gameController.GetComponent<Score> ();
				m_scoreScript.BonusScore (1000f, "NearMiss");
			}
		}
	}
}
