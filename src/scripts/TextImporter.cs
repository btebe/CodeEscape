using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
/**
 * csis 490 project
 * project name: CodeEscape
 * TextImporter.cs
 * purpose: to read files from asset and display in dialog box
 * @author basmatebe
 * @version beta 3/12/2017
 */
public class TextImporter : MonoBehaviour {


	public TextAsset txtfile;
	public Text ptext;
	//public string txtcnts; 

	string textContent;
	// Use this for initialization
	void Start () {

		if (txtfile != null) {
			ptext.text = (txtfile.text);
		}


	}





}
