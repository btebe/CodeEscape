using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
 * csis 490 project
 * project name: CodeEscape
 * UserInput.cs
 * purpose: This is the main class to get user input from the game
 * @author Samy A
 * @version 1.0 3/12/2017
 */
public class UserInput : MonoBehaviour {

	/*
	 * This is the main class to get user input from the game
	 */
	public InputField input;
	public Text ftext;
	public static string anser;
	private QuestManager theQM;
	private QuestObject theQO;
	public writetofile wrt;
	private bool case2 = false;

	//like start()
	void Awake(){
		//the object itself
		theQM = FindObjectOfType<QuestManager> ();
		theQO = FindObjectOfType<QuestObject> ();
		if (input.gameObject.activeSelf) {
			input = GameObject.Find ("InputField").GetComponent<InputField>();
		}

		//wrt= new writetofile();
	}
	public void GetUserInput(){
		if (input.text != null) {
			anser = input.text;
			input.text = "";
		}
	}
	void Update(){
		wrt= new writetofile();

	}

	public void hide_show_panel(){
		if (input.gameObject.activeSelf) {
			input.gameObject.SetActive (false);
		} else {
			input.gameObject.SetActive (true);
		}

	}
	/*
	 * Whenever the user presses submit this method is called,
	 * the linechanger and cmd methods come from the writetofile class.
	 * this is where the user code is dealt with
	 */
	public void GetInput(){
		if (input.text != null) {
			//wrt= new writetofile();
			//Time.timeScale = 0f;
			wrt.lineChanger (input.text, "eg.java", 3);
			wrt.cmd ("javac eg2.java");
			StartCoroutine (wrt.Example ());
			input.text = "";
		}
		//Time.timeScale = 1f;
	}

}
