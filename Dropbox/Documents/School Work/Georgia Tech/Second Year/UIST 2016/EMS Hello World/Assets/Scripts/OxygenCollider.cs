using UnityEngine;
using System.Collections;

public class OxygenCollider : MonoBehaviour
{
	float radius;

	// Use this for initialization
	void Start ()
	{
		//SphereCollider sc = this.transform.GetComponent<SphereCollider>();
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.name == "Hydrogen")
		{
			//do something
			Debug.Log("Hydrogen entered");
		}
	}
}
