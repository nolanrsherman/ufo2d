using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour {
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		moveForward ();

	}

	private void moveForward(){
		transform.position += new Vector3 (0, speed, 0);
	}
}
