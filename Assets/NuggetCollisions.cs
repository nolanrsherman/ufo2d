using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuggetCollisions : MonoBehaviour {
	public GameManager gameManager;
	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindObjectOfType<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Collider detected");
		if (other.gameObject.CompareTag("laser") ) {
			Debug.Log ("Collision with laser");

			other.gameObject.SetActive (false);

			gameManager.decrementPickup();
		}
	}
}
