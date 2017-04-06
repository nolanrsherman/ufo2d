using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This scripts handles collisions between objects.
 * 1. Attach to object 1 (must have a collider2d and a rigidbody2d)
 * 2. pass object 2 into "otherObject" in editor.
 * 3. pass script attached to this object with a OnCollision() method.
 * 
 * */

public class DestroyOnCollision : MonoBehaviour {
	public GameObject otherObject;
	public bool destroyThis = true;
	public bool destroyOther = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == otherObject.name ) {
			Debug.Log( otherObject.name + " collided with " + this.gameObject.name );

			if(destroyOther)
			Destroy (other.gameObject);

			if(destroyThis)
			Destroy (this.gameObject);
		}
			
	}
}
