using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * csis 490 project
 * project name: CodeEscape
 * QuestManager.cs
 * purpose: to manage quest objects
 * @author basmatebe
 * @version beta 3/12/2017
 */
public class QuestManager : MonoBehaviour {

	public QuestObject[] quests; // can add and drop objects of type QuestObject manually from unity
	public bool[] questCompleted; //keep track which quests has been completed
	public DialogManager theDM;
	public string itemCollected;

	// Use this for initialization
	void Start () {
		//questcomplete.len should equal quests.len
		//to mark compeleted quest as true during the game
		questCompleted = new bool[quests.Length];
	
	}
	//to show texts in the Dialog box
	public void showQuestText(string questText){
		theDM.dialogLines = new string[1];
		theDM.dialogLines [0] = questText;
		theDM.currentLine = 0;
		theDM.showDialog ();
	}
}
