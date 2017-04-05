using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private int score;
	public int numberOfPickups;
	public LevelManager levelmanager;

	// Use this for initialization
	void Start () {
		numberOfPickups = GameObject.FindGameObjectsWithTag ("pickup").Length;
		levelmanager = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void decrementPickup(){
		numberOfPickups--;
	}

	void CheckForWin() {
		if (numberOfPickups == 0) {

			levelmanager.LoadWin ();
		} 
	}
		
}
