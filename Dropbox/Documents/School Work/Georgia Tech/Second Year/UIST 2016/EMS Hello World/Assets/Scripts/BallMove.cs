using UnityEngine;
using System.Collections;

public class BallMove : MonoBehaviour
{
	public GameObject ball;
	public GameObject cube;
	public float speed;

	// Use this for initialization
	void Start ()
	{
		ball = GameObject.Find ("Sphere");
		cube = GameObject.Find ("Cube");
	}
	
	// Update is called once per frame
	void Update ()
	{
		float step = speed * Time.deltaTime;
		ball.transform.position = Vector3.MoveTowards(ball.transform.position, cube.transform.position, step);
	}
}
