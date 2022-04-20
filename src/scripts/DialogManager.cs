using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * csis 490 project
 * project name: CodeEscape
 * DialogManager.cs
 * purpose: To manage the dialog lines in a dialog box
 * @author basmatebe
 * @version beta 3/12/2017
 */
public class DialogManager : MonoBehaviour {


	public GameObject dBox;
	public Text dtext;
	public bool dialogActive;
	public string[] dialogLines;
	public int currentLine;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//press space bar to erase or to go to next line
		if (dialogActive && Input.GetKeyDown(KeyCode.Space)) {
			currentLine++;
		}
		//erase text
		if (currentLine >= dialogLines.Length) {
			dBox.SetActive (false);
			dialogActive = false;
			currentLine = 0;

		} else {
			//dBox.SetActive (true);
			dialogActive = true;
			dtext.text = dialogLines [currentLine];

		}
			

	}

	//to activate dialog box
	public void showDialog(){
		dialogActive = true;
		dBox.SetActive (dialogActive);
	}
}
