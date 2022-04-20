using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * csis 490 project
 * project name: CodeEscape
 * PauseMenu.cs
 * purpose: to direct the player to the same or different scenes
 * @author basmatebe
 * @version beta 3/12/2017
 */
public class PauseMenu : MonoBehaviour
{
	/*
   names of the sences
     */
	public string relesson;
	public string nextLesson;
	public string menu;
	public string level;

	/*
    for pausing and unpausing pauseMenu window
     */
	public bool isPaused;
	//by default true

	/*
    Objects within the game
     */
	public GameObject door;
	//public GameObject furniture;
	public GameObject nextroom;
	public GameObject pausemenu;
	public QuestManager theQM;


	/*
    checks if all the tasks are completed
     */
	public bool taskNotComplete (bool[] a)
	{
		for (int i = 2; i < a.Length; i++) {
			if (a [i] != true) {
				return false;
			}
		}
		return true;
	}

	/*public IEnumerator ex ()
	{
		yield return new WaitForSeconds (3);
	}*/
	// Update is called once per frame
	void Update ()
	{
		//checks if pause is true and all the tasks are completed and the pause menu is inactive
		if (isPaused && (taskNotComplete (theQM.questCompleted) == true) && !pausemenu.activeSelf) {
			
			//ex ();
			pausemenu.SetActive (true);// make pause menu window appear
			Time.timeScale = 0f;//stop time

		} else if (!isPaused) {
			pausemenu.SetActive (false);//make pause window disappear
			door.SetActive (false);// make door disappear
			nextroom.SetActive (true);//set trigger active
			Time.timeScale = 1f; //revert back the time
			if (theQM.quests [1].gameObject.activeSelf) {
				theQM.quests [1].endQuest ();
			}

		}

		// the player can use escape button to resume the game
		if (Input.GetKeyDown (KeyCode.Escape) && !isPaused) {
			isPaused = !isPaused;

		}
	}


	/*
    player can replaye the lesson or the room
     */
	public void replayLesson ()
	{
		SceneManager.LoadScene (relesson);﻿
		Time.timeScale = 1f;//revert back the time
	}

	/*
    player can proceed to the next lesson or next room
     */
	public void nxtLesson ()
	{
		isPaused = false;

	}

	/*
    player can proceed to the next level
     */
	public void nxtLevel ()
	{
		isPaused = false;
		LockedOrNot.lockStatus = 0;//open lock

	}

	/*
    player can repeat level
     */
	public void replyLevel ()
	{
		SceneManager.LoadScene (level);﻿
		Time.timeScale = 1f;//revert back the time

	}

	/*
    direct player back to main menu
     */
	public void backToMenu ()
	{
		isPaused = false;
		SceneManager.LoadScene (menu);﻿
	}
}
