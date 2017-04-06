using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GirderSpawn : MonoBehaviour 
{

    public int[] rotation;
    public GameObject girder;
    public int randomInt;

	private Button m_shieldButton;
	private int m_shieldAmount;

	public Image buttonImage;
	public Sprite deactiveImage;
	public Sprite activeImage;
	public Text m_shieldButtonText;

	public void Start()
	{
		m_shieldButton =  GetComponent<Button> ();
		m_shieldButton.interactable = false;
		m_shieldButtonText.text = "" + m_shieldAmount;
	}

	public void AddShield()
	{
		m_shieldAmount += 1;
		m_shieldButton.interactable = true;
		buttonImage.sprite = activeImage;
		m_shieldButtonText.text = "" + m_shieldAmount;
	}

	// Update is called once per frame
	public void spawnGirder ()
    {
		if (m_shieldAmount > 0) {
        randomInt = Random.Range(0, 4);
        Instantiate(girder, new Vector3(0,0,0), Quaternion.Euler(transform.rotation.x, 180, rotation[randomInt]));
	} else {
		m_shieldButton.interactable = false;
	}
	m_shieldAmount -= 1;
	if (m_shieldAmount == 0) {
		m_shieldButton.interactable = false;
	}
	m_shieldButtonText.text = "" + m_shieldAmount;
    }
}