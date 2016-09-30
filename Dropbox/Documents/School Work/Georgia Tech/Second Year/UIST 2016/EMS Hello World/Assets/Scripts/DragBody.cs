using UnityEngine;
using System.Collections;

public class DragBody : MonoBehaviour
{

	public Vector3 screenPoint;
	public Vector3 offset;

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		
	}

	// void OnMouseDrag()
	// {
	// 	float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
	// 	transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen ));
	// }

	void OnMouseDown()
	{
    	screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}


	void OnMouseDrag()
	{
	    Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
	 	Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
	 	transform.position = curPosition;
	}
}
