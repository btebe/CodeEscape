using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/**
 * csis 490 project
 * project name: CodeEscape
 * RoomLoader.cs
 * purpose: to load player to a certain room
 * @author basmatebe
 * @version beta 3/12/2017
 */
public class RoomLoader : MonoBehaviour {


	public string levelToLoad;
	public string exitPoint;//name of the point in the next room
	private PlayerController pc;


	// Use this for initialization
	void Start () {
		pc = FindObjectOfType<PlayerController> ();
	}
		
	/*
    when player enters a trigger zone load player to the next room
     */
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "player") {
			pc.startPoint = exitPoint;//to position player to a specific point in the next room
			SceneManager.LoadScene(levelToLoad);﻿
		}
	}

}
