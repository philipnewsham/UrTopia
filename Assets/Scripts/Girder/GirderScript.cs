using UnityEngine;
using System.Collections;

public class GirderScript : MonoBehaviour {

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
}
