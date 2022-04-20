using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * csis 490 project
 * project name: CodeEscape
 * QuestObject.cs
 * purpose: the contents of a quest object
 * @author basmatebe
 * @version beta 3/12/2017
 */
public class QuestObject : MonoBehaviour {

	public int questNumber;// to kno what number of the quest we're on. this needs to be added manually on unity

	public QuestManager theQM; //why public? so we dont instantiate new questmanager for every quest. its always gonna be static

	public string questAnswer;
	public string startText;
	public string endText;
	public string wrongAnser;
	public GameObject item;
	public bool isitemQuest;
	public string tragetItem;
	public GameObject obj;


	
	// Update is called once per frame
	void Update () {
		if (isitemQuest) {//check there's an item in the quest
			//check if item is the target
			if (theQM.itemCollected == tragetItem) {
				item.SetActive(true);//make item appear
				theQM.itemCollected = null;//clear the itemcollected string
				endQuest ();
			}
		}
	}
	//show start quest text
	public void startQuest(){
		theQM.showQuestText (startText);
	}

	//to deactivate quest
	public void endQuest(){
		theQM.showQuestText (endText);
		theQM.questCompleted [questNumber] = true; //so quest dont start again
		gameObject.SetActive (false);
	}

	public void wronganser(){
		theQM.showQuestText (wrongAnser);

	}



}
