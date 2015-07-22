using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public int turns;
	public GameObject active;
	public Transform actors;
	private BoardManager boardscript;
	private Actor actorscript;
	public bool enemiesturn, playersturn;


	// Use this for initialization
	void Start () {
		boardscript = GetComponent <BoardManager>();
		boardscript.enabled = true;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (playersturn || enemiesturn) return; 
		MoveEnemies ();
	}

	public void SetActive() //This needs to be called after the setup is done on the board BY the board object.
	{
		active = GameObject.FindWithTag ("Active Level");
		actors = active.transform.Find ("Actors");
		//GameLoop ();

	}

	private void MoveEnemies()
	{
			enemiesturn = true;
			foreach (Transform child in actors.transform) 
			{
				actorscript = child.gameObject.GetComponent<Actor> (); //Grab reference to Actor script through transform
				actorscript.Act ();
				
			}
			enemiesturn = false;
		playersturn = true;
		}



}

