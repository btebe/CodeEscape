using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * csis 490 project
 * project name: CodeEscape
 * DialogHolder.cs
 * purpose: for holding dialogs with no quests. useful for tutorials
 * @author basmatebe
 * @version beta 3/12/2017
 */
public class DialogHolder : MonoBehaviour {
	//
	public string dialogue;
	private DialogManager dman;
	public string[] dialogLines;
	public TextAsset txtfile;
	private string x;
	private QuestManager theQM;

	// Use this for initialization
	void Start () {
		dman = FindObjectOfType<DialogManager> (); //e.g dialogzones are of type DialogManger
		theQM = FindObjectOfType<QuestManager> ();
		
	}

	//when tirggered, text show up in the dialog box
	public void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "player") {
			//dman.showBox (dialogue);
			//.Split('@')
			x = "hello, world";
			if (dman.dialogActive) {
				if (txtfile != null) {
					dman.dialogLines = (txtfile.text).Split('@');
					//dman.currentLine = 0;
					dman.dialogActive = true;
					dman.showDialog ();

				} else {
					/*dman.dialogLines = dialogLines;
					dman.dialogActive = true;
					dman.currentLine = 0;
					dman.showDialog ();*/
					//dman.dialogActive = true;
					theQM.showQuestText (dialogue);
				}
			}
		 
		}
	}
}
