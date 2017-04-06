using UnityEngine;
using System.Collections;

public class RainCloudDamage : MonoBehaviour {

    public float startDelay = 5;
    public float planetHealth;
    public float maxDamage;
    public bool takingConstantDamage;
    public bool stormOn;
    public GameObject lightning01;
    public GameObject lightning02;

	// Use this for initialization
	void Start () 
    {
        stormOn = true;
        StartCoroutine(LightningFlash());
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        planetHealth = GameObject.FindWithTag("Planet").GetComponent<PlanetHP>().health;

        startDelay -= 1 * Time.deltaTime;
        if(startDelay <= 0)
        {

            startDelay = 0;

        }
	
	}
    IEnumerator LightningFlash()
    {
        while(stormOn)
        {

            lightning01.SetActive(true);
            yield return new WaitForSeconds(0.05f);
            lightning01.SetActive(false);
            yield return new WaitForSeconds(2f);
            lightning02.SetActive(true);
            yield return new WaitForSeconds(0.05f);
            lightning02.SetActive(false);
            yield return new WaitForSeconds(1.5f);
            if(stormOn == false)
            {
                break;
            }
        }

    }
}
