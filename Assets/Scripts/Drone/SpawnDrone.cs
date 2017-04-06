using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SpawnDrone : MonoBehaviour {

    public Vector3[] position;
    public GameObject drone;
    public int randomInt;

	private Button m_droneButton;
	private int m_droneAmount;

	public Image buttonImage;
	public Sprite deactiveImage;
	public Sprite activeImage;
	public Text m_droneButtonText;
    // Use this for initialization
    void Start () 
	{
		m_droneButton =  GetComponent<Button> ();
		m_droneButton.interactable = false;
		m_droneButtonText.text = "" + m_droneAmount;
	}

	public void AddDrone()
	{
		m_droneAmount += 1;
		m_droneButton.interactable = true;
		buttonImage.sprite = activeImage;
		m_droneButtonText.text = "" + m_droneAmount;
	}

    public void DroneSpawner()
    {
		if (m_droneAmount > 0) {
			randomInt = Random.Range (0, 4);
			Instantiate (drone, new Vector3 (position [randomInt].x, position [randomInt].y, position [randomInt].z), Quaternion.identity);
		} else {
			m_droneButton.interactable = false;
		}
		m_droneAmount -= 1;
		if (m_droneAmount == 0) {
			m_droneButton.interactable = false;
		}
		m_droneButtonText.text = "" + m_droneAmount;
    }
}
