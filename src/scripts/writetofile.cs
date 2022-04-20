using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; 
using System.Diagnostics;
using System.Text;
using UnityEngine.UI;

/**
 * csis 490 project
 * project name: CodeEscape
 *  writetofile.cs
 * purpose: This is the main class for taking the user code and writing it to a
 * java file, and to use the Windows cmd prompt window
 * @author Samy A
 * @version beta 3/12/2017
 */
public class  writetofile : MonoBehaviour {
	

	public string output;
	/*
	 * This method is used to read from a .txt file that already has 
	 * the main structure for a Java class, add the new lines of code that the user types but outputs everything to a .java file
	 * @param newText	Whatever lines of code the user types
	 * @param filename	the name of the txt file that has the java structure
	 * @param line_to_edit	the line number of where to add the new code
	 */
	public  void lineChanger(string newText, string fileName, int line_to_edit)
	{
		string[] arrLine = File.ReadAllLines(fileName);
		arrLine[line_to_edit - 1] = newText;
		File.WriteAllLines("eg2.java" , arrLine);
	}
	/*
	 * This method is a bit complicated to explain, the main purpose 
	 * of it is to wait 0.6 seconds untill the cmd prompt window is done compiling 
	 * the .java file and creates its .class file
	 * then it waits again 0.8 seconds so that it can read from the output txt file
	 * the waiting process is needed since it takes sometime for the cmd window to execute everything
	 */

	/*void Updat(){
		Example ();
	}*/


	public IEnumerator Example()
	{
		//System.IO.File.WriteAllText("txt.txt",string.Empty);
		yield return new WaitForSeconds(0.6f);
		cmd ("java eg2 > txt.txt");
		yield return new WaitForSeconds(0.8f);
		output=	ReadString ();
		//UnityEngine.Debug.Log ("Output = " + output);
	}



	/*
	 * This method is called used to call the cmd.exe program from unity and passing it a command line
	 * @param cmdAr	command line that's sent to cmd 
	 */
	public  void cmd(string cmdAr){
		System.Diagnostics.Process process = new System.Diagnostics.Process();
		System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
		startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
		startInfo.UseShellExecute = false;
		startInfo.FileName = "/bin/bash";
		startInfo.Arguments = "-c \" " + cmdAr + " \"";
		process.StartInfo = startInfo;
		process.Start();
	}
	/*
	 * This is to read the output of the user written code from the txt file
	 * @returns the string output 
	 */
	public  string ReadString()
	{
		StreamReader reader = new StreamReader ("txt.txt");
		output = reader.ReadToEnd();
		reader.Close();
		return output;
	}


}
