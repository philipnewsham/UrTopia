using UnityEngine;
using System.Collections;

public class SentryScript : MonoBehaviour {

    public GameObject sentryTop;
    public GameObject sentryBottom;
    public ParticleSystem burst;
    private float resetTime = 0.3f;
    public float lifetime = 5f;

	// Use this for initialization
	void Start () {
	
	}
    void Update()
    {
        lifetime -= 1 * Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);

        }
    }
    IEnumerator OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Enemy"|| col.gameObject.tag == "Meteor")
        {
            sentryTop.transform.position = new Vector3 (transform.position.x, transform.position.y + 0.02f, transform.position.z);
            sentryBottom.transform.position = new Vector3 (transform.position.x, transform.position.y - 0.02f, transform.position.z);
            burst.gameObject.SetActive(true);
            yield return new WaitForSeconds (resetTime);
            burst.gameObject.SetActive(false);
            sentryTop.transform.position = new Vector3 (transform.position.x, transform.position.y - 0.25f, transform.position.z);
            sentryBottom.transform.position = new Vector3 (transform.position.x, transform.position.y + 0.25f, transform.position.z);
        }
    }

}
