using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * csis 490 project
 * project name: CodeEscape
 * CameraController.cs
 * purpose: to make camera follow player. also one camera should be used throughout the whole rooms
 * @author basmatebe
 * @version beta 3/12/2017
 */
public class CameraController : MonoBehaviour {


	public GameObject followTarget;
	private Vector3 targetPosition;
	public float moveSpeed;

	private static bool cameraExist;
	// Use this for initialization
	void Start () {
		if (!cameraExist) {
			cameraExist = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject);//if camera exists in the next room destroy it
		}
	}
	
	// Update is called once per frame
	//make camera follow player
	void Update () {
		targetPosition = new Vector3 (followTarget.transform.position.x, 
			followTarget.transform.position.y, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, targetPosition, 
			moveSpeed * Time.deltaTime);
	}
}
