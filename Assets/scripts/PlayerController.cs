using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Rigidbody2D rb;
	public float speed;
	private int numberOfPickups;
	private LevelManager levelmanager;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.freezeRotation = true; //no rotation
		levelmanager = GameObject.FindObjectOfType<LevelManager> ();
		numberOfPickups = GameObject.FindGameObjectsWithTag ("pickup").Length;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		//float moveVertical = Input.GetAxis ("Vertical");// dont need this anymore
		Vector2 movement = new Vector2 (moveHorizontal, 0);//0 vertical, we only want to move left to right
		rb.AddForce(movement * speed);
		CheckForWin ();

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("pickup") ) {
			other.gameObject.SetActive (false);
			numberOfPickups--;
		}
		if (other.gameObject.CompareTag ("boundry")) {
			
		}
	}

	void CheckForWin() {
		if (numberOfPickups == 0) {
			levelmanager.LoadWin ();
		}
	}
}
