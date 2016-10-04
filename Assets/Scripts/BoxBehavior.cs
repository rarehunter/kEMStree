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
	}

	// Update is called once per frame
	void Update ()
	{

	}

	// On click, instantiate a new atom depending on the box that was clicked
	void OnMouseDown()
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

		clone = (GameObject)Instantiate(prefab_to_instatiate, hit.point, Quaternion.identity);
	}

	// While the mouse is held, move the atom to where it should be placed.
	// Turn off rigidbody while doing so because otherwise, the physics engine updating
	// gets pretty crazy (disabling rigidbody by turning on/off isKinematic respectively)
	void OnMouseDrag()
	{
		clone.GetComponent<Rigidbody>().isKinematic = true;
		Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);

		RaycastHit hit2;
		if(Physics.Raycast(ray2, out hit2, Camera.main.farClipPlane))
		{
			float oldY = clone.transform.position.y;
			clone.transform.position = new Vector3(hit2.point.x, oldY, hit2.point.z);
		}
		clone.GetComponent<Rigidbody>().isKinematic = false;

	}

}
