using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Rigidbody2D rb;
	public float speed;

	public GameObject laserPrefab;
	public float laserOffsetX1;
	public float laserOffsetY1;
	public float laserOffsetX2;
	public float laserOffsetY2;

	private bool mouseDown = false;

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

		onClick ();
		CheckForWin ();

	}

	void onClick(){
		//check for click or touch.
		bool leftClick = Input.GetKeyDown(KeyCode.Mouse0);
		if (leftClick) {
			mouseDown = true;
			Vector3 laserLocation1 = this.gameObject.transform.position + new Vector3 (laserOffsetX1, laserOffsetY1, 0);
			Vector3 laserLocation2 = this.gameObject.transform.position + new Vector3 (laserOffsetX2, laserOffsetY2, 0);

			Instantiate (laserPrefab, laserLocation1, new Quaternion(0f,0f,0f,0f));
			Instantiate (laserPrefab, laserLocation2, new Quaternion(0f,0f,0f,0f));
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("pickup") ) {
			other.gameObject.SetActive (false);
			numberOfPickups--;
		}
	}

	void CheckForWin() {
		if (numberOfPickups == 0) {
			
			levelmanager.LoadWin ();
		} 
	}
}
