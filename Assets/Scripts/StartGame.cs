using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	public GameObject[] uiElements;
	public GameObject[] playButtons;

	public void GameStart()
	{
		for (int i = 0; i < uiElements.Length; i++) {
			uiElements [i].SetActive (true);
		}
		for (int i = 0; i < playButtons.Length; i++) {
			playButtons[i].SetActive (false);
		}

	}
}
