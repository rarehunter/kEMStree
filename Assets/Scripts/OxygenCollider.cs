using UnityEngine;
using System.Collections;

public class OxygenCollider : MonoBehaviour
{
	private int max_hydrogens = 2;
	private int num_hydrogens;

	// Use this for initialization
	void Start ()
	{
		num_hydrogens = 0;
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void OnCollisionEnter(Collision collision)
	{
		GameObject atom_entering = collision.gameObject;
		GameObject this_atom = this.gameObject;

		if(atom_entering.name == "HydrogenPrefab(Clone)" && num_hydrogens < max_hydrogens)
		{
			// Vector3 fta = 10 * Vector3.up;
			// Debug.Log(fta);
			//
			// atom_entering.GetComponent<Rigidbody>().AddForce(fta, ForceMode.Impulse);

			// First, make the hydrogen a child of this oxygen atom.
			// Next, create a Fixed Joint component on the hydrogen and stick it to the oxygen
			atom_entering.transform.parent = this_atom.transform;
			atom_entering.AddComponent<FixedJoint>();
            atom_entering.GetComponent<FixedJoint>().connectedBody = this_atom.GetComponent<Rigidbody>();

			num_hydrogens += 1;

		}
	}
}
