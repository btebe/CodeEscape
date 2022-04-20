using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * csis 490 project
 * project name: CodeEscape
 * QuestTrigger.cs
 * purpose: to when start and  when to end quest
 * @author basmatebe
 * @version beta 3/12/2017
 */

public class QuestTrigger : MonoBehaviour {


	/*
	 * This is the main class for handling when a quest should be triggered
	 */
	private QuestManager theQM;
	public int questNumber;
	public bool startQuest;//triggerzones that have startquest ticked to be marked as startquest zone
	public bool endQuest;//triggerzones that have endzones ticked to be marked as endquest zone
	public writetofile wrt;
	//public UserInput us;
	// Use this for initialization
	void Start () {
		theQM = FindObjectOfType<QuestManager> ();// so triggers will always have questmanager attached to it
		//wrt = new writetofile ();
		//us = new UserInput();

	}

	// Update is called once per frame
	void Update () {
		//wrt = new writetofile ();
		//us.wrt = new writetofile();
		//StartCoroutine (ex ());
		if (theQM.quests [questNumber].gameObject.activeSelf && !theQM.questCompleted [questNumber]) {
			wrt = new writetofile ();
			StartCoroutine (ex ());
		}


	}
	/*
	 * This is where we check if the output is equal to the correct answer for the quest
	 * it needs to wait 1.5 seconds before it checks the answer
	 */
	public IEnumerator ex()
	{
		//wrt.ReadString () 
		yield return new WaitForSeconds (1.5f);

		wrt.ReadString ();
		string val = wrt.output;
		if (val == theQM.quests [questNumber].questAnswer && !theQM.questCompleted [questNumber] ) {
			//Debug.Log ("Output = " + val);
			if(theQM.quests [questNumber].obj != null){
				theQM.quests [questNumber].obj.SetActive (false);
			}

			theQM.quests [questNumber].endQuest ();
		}

	}

	//when player enters the zone 
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "player") {

			//check if quest already been completed so then dont worry at all
			//if the value of quest number in this array equal to false
			if (!theQM.questCompleted [questNumber]) {

				//i think by default gameobject are set to be not active
				//if in the start quest zone and that quest gameobject is deactived.
				//if game object quest 2 in unity object panel is actived in the game
				if (startQuest && !theQM.quests [questNumber].gameObject.activeSelf) {
					// activate object
					theQM.quests [questNumber].gameObject.SetActive (true);
					theQM.quests [questNumber].startQuest ();

				}
				// if player in the end quest zone and quest gameobject quest is active
				if (endQuest && theQM.quests [questNumber].gameObject.activeSelf) {
					
					//it deactivates objects quest e.g quest 2
					theQM.quests [questNumber].endQuest ();


				}


			}
		}
	}
}
