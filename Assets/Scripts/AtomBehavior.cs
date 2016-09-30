using UnityEngine;
using System.Collections;

public class AtomBehavior : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}

	// void OnTriggerEnter(Collider other)
	// {
	// 	if(other.gameObject.name == "OxygenPrefab(Clone)")
	// 	{
	// 		other.gameObject.transform.parent = gameObject.transform;
	// 	}
	// }

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.name == "OxygenPrefab(Clone)")
		{
			collision.gameObject.transform.parent = gameObject.transform;
		}
	}

	void OnMouseDrag()
	{
		// Code to make an atom follow the mouse cursor
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, Camera.main.farClipPlane))
		{
			float oldY = transform.position.y;
			this.transform.position = new Vector3(hit.point.x, oldY, hit.point.z);
		}

	}

	// void OnMouseUp()
	// {
	// 	Debug.Log("Mouse released");
	// 	this.GetComponent<Rigidbody>().velocity = Vector3.zero;
	// }

}
