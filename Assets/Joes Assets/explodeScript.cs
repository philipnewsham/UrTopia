using UnityEngine;
using System.Collections;

public class explodeScript : MonoBehaviour {


    public float radius = 50;
    public float power = 1000;
    public float lifetime;
    public ParticleSystem thrusterParticles;
    public ParticleSystem explodeParticles;
    public bool HasExploded;
    //private float rotateSpeed;
    //public float rotate;

    void Start()
    {
        //rotateSpeed = rotate * Time.deltaTime;
    }



	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown("e"))
        {
            HasExploded = true;
        }
        if(HasExploded)
        {
            lifetime -= 1 * Time.deltaTime;
            if(lifetime <= 0)
            {
                Destroy(gameObject);

            }
            GetComponent<rotateObject>().enabled = false;
            foreach (Transform child in transform)
            {
                explodeParticles.gameObject.SetActive(true);
                thrusterParticles.gameObject.SetActive(false);
                child.GetComponent<Rigidbody>().AddExplosionForce(power * 10,child.transform.position+Random.insideUnitSphere*radius,radius,3.0f);
                //child.GetComponent<Rigidbody>().AddTorque(transform.right * rotateSpeed);

            }
        }


	
	}

}
