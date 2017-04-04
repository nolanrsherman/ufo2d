using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.position = this.gameObject.transform.position + new Vector3 (0, speed, 0);
	}

	public void setSpeed(float speed){
		this.speed = speed;
	}
}
