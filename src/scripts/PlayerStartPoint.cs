using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * csis 490 project
 * project name: CodeEscape
 * PlayerStartPoint.cs
 * purpose: to posistion the player in the world
 * @author basmatebe
 * @version beta 3/12/2017
 */
public class PlayerStartPoint : MonoBehaviour {

	private PlayerController pc;
	private CameraController cc;
	public Vector2 startDirection;
	public string pointName;


	// Use this for initialization
	void Start () {
		//find player that has this script attached to it
		pc = FindObjectOfType<PlayerController> ();
		if (pointName != null || pointName != " ") {
			if (pc.startPoint == pointName) {
				//find position in the world to where the start point is;
				pc.transform.position = transform.position;
				pc.lastMove = startDirection;

				cc = FindObjectOfType<CameraController> ();
				//get z value from camera not from player start point is attached
				cc.transform.position = new Vector3 (transform.position.x, transform.position.y, cc.transform.position.z);
			}
		}

	}
	

}
