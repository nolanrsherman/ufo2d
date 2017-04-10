using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Rigidbody2D rb;
	public float speed;
	public GameObject projectile;

	private int numberOfPickups;
	private LevelManager levelmanager;

	public float gun1x = 0;
	public float gun1y = 0;
	public float gun2x = 0;
	public float gun2y = 0;

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

			Vector3 relativePosition = new Vector3(gun1x,gun1y,0);
			Quaternion rotation = new Quaternion(0f,0f,0f,0f);
			Instantiate (projectile, this.transform.position + relativePosition, rotation, this.transform);//left gun laser

			relativePosition = new Vector3(gun2x,gun2y,0);
			Instantiate (projectile, this.transform.position + relativePosition, rotation, this.transform);//Right gun laser
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
