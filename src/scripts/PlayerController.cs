using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * csis 490 project
 * project name: CodeEscape
 * PlayerController.cs
 * purpose: controlled movements on the player. also there exist one player throught the whole game
 * @author basmatebe
 * @version beta 3/12/2017
 */
public class PlayerController : MonoBehaviour {

	public float moveSpeed;

	private Animator anim;
	private Rigidbody2D myRidgidPlayer;

	private bool playerMoving;

	public Vector2 lastMove;
	private static bool playerExist;
	public string startPoint;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		myRidgidPlayer = GetComponent<Rigidbody2D> ();
		if (!playerExist) {
			playerExist = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject);
		}

	}
	
	// Update is called once per frame
	void Update () {
		playerMoving = false;
		//move player to right & left
		if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f ) {

			//transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
			myRidgidPlayer.velocity = new Vector2(Input.GetAxisRaw ("Horizontal") * moveSpeed, myRidgidPlayer.velocity.y);
			playerMoving = true;
			lastMove = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0f);
		}
		//move player up & down
		if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f ) {


			myRidgidPlayer.velocity = new Vector2(myRidgidPlayer.velocity.x, Input.GetAxisRaw ("Vertical") * moveSpeed);
			playerMoving = true;
			lastMove = new Vector2 (0f, Input.GetAxisRaw ("Vertical"));
		}

		if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f) {
			myRidgidPlayer.velocity = new Vector2 (0f, myRidgidPlayer.velocity.y);
		}

		if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f) {
			myRidgidPlayer.velocity = new Vector2 (myRidgidPlayer.velocity.x, 0f);
		}

		anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
		anim.SetBool ("PlayerMoving", playerMoving);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);
				
		
	}
}
