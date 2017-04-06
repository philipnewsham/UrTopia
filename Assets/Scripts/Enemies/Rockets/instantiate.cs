using UnityEngine;
using System.Collections;

public class instantiate : MonoBehaviour {

	public GameObject prefab;

	void Start()
	{
		
			Instantiate(prefab, new Vector3(2.0f, 0, 0), Quaternion.identity);
	}
}