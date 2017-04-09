using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Rigidbody2D rb;
	public float speed;
	public GameObject projectile;

	private int numberOfPickups;
	private LevelManager levelmanager;
	private bool clickPressed = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.freezeRotation = true;

		levelmanager = GameObject.FindObjectOfType<LevelManager> ();
		numberOfPickups = GameObject.FindGameObjectsWithTag ("pickup").Length;
	}
	
	// Update is called once per frame
	void Update(){
		onClick ();
	}

	void FixedUpdate () {
		//Handle Input
		movement();

		//End Handle Input
		LoadNextLevel ();

	}

	private void onClick(){

		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			Debug.Log ("mouse clicked");
			Instantiate (projectile, this.transform);
		} 
	}

	private void movement(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb.AddForce (movement * speed);
	}
		

	private void LoadNextLevel() {
		if (numberOfPickups == 0) {
			levelmanager.LoadWin ();
		}
	}
}
