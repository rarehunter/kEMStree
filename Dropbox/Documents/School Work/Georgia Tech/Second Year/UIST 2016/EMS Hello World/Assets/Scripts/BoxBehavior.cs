using UnityEngine;
using System.Collections;

public class BoxBehavior : MonoBehaviour
{
	public GameObject oxygenPrefab;
	public GameObject hydrogenPrefab;
	public static bool atom_held;
	private GameObject clone;

	private GameObject prefab_to_instatiate;
	private RaycastHit hit;

	// Use this for initialization
	void Start ()
	{
		atom_held = false;
	}

	// Update is called once per frame
	void Update ()
	{

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit, Camera.main.farClipPlane))
		{
			string go_name = hit.collider.gameObject.name;

			if(go_name == "OxygenBox")
				prefab_to_instatiate = oxygenPrefab;
			if(go_name == "HydrogenBox")
				prefab_to_instatiate = hydrogenPrefab;
		}

	}


	void OnMouseDown()
	{
		clone = (GameObject)Instantiate(prefab_to_instatiate, hit.point, Quaternion.identity);
	}

	void OnMouseDrag()
	{
		// Code to make an atom follow the mouse cursor
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		RaycastHit hit2;
		if(Physics.Raycast(ray, out hit2, Camera.main.farClipPlane))
		{
			float oldY = transform.position.y;
			clone.transform.position = new Vector3(hit2.point.x, oldY, hit2.point.z);
		}
	}
	void OnMouseUp()
	{
		// Debug.Log("Mouse released");
		// clone.GetComponent<Rigidbody>().velocity = Vector3.zero;
	}

}
