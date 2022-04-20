using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/**
 * csis 490 project
 * project name: CodeEscape
 * MainMenu.cs
 * purpose: options for the player to choose from
 * @author basmatebe
 * @version beta 3/12/2017
 */
public class MainMenu : MonoBehaviour {
	/*
   names of the scenes
     */
	public string levelsPg;
	public string infoPage;

	/*
   direct player to levels page
     */
	public void start(){
		SceneManager.LoadScene(levelsPg);﻿

	}

	/*
   direct player the game info page
     */
	public void gameInfo(){
		SceneManager.LoadScene(infoPage);﻿
	}
	/*
   an option to quit the whole game
     */
	public void quitGame(){
		Application.Quit(); //wont close whithin the editor
	}
}
