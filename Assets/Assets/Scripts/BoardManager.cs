using UnityEngine;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

	public int rows = 10;
	public int columns = 10;
	private List <Vector3> gridpositions = new List <Vector3> ();
	public GameObject[] floorTiles;
	public GameObject[] Actors;
	public GameObject MainCamera;
	private GameObject boardHolder;
	private GameObject actorHolder;
	GameObject Controller;


	// Use this for initialization
	void Start () 
	{
		Initializelist (); //Generates grid coordinates for every tile
		Fillboard (); // Fills the board with randomized ground tiles
		Populate (); // Adds all the actors stored in the Actor array.
		Finish(); // Tells the Game Manager setup is done and to set the level as Active

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Initializelist()
	{
		gridpositions.Clear ();
		for (int x = 0; x<columns; x++) {
			for (int y = 0; y<rows; y++) {
				gridpositions.Add (new Vector3 (x, y, 0f));
			}
		}
	}

	void Fillboard()
	{
		boardHolder = new GameObject ("ActiveLevel");
		boardHolder.tag = "Active Level";
		actorHolder = new GameObject ("Actors"); //More Hierarchy, wasn't working right
		actorHolder.transform.parent = boardHolder.transform;
		for (int x = 0; x < columns; x++)
		{
			for (int y = 0; y < rows; y++)
			{
				GameObject toInstantiate = floorTiles[Random.Range(0,floorTiles.Length)];
				GameObject instance = Instantiate(toInstantiate, new Vector3(x,y,0f), Quaternion.identity) as GameObject;
				instance.transform.parent = boardHolder.transform;
			}
		}
	}

	void Populate()
	{


		//actorHolder = boardHolder.Find (Actors);
		foreach (GameObject actor in Actors) {

			GameObject instance = Instantiate (actor, actor.transform.position, Quaternion.identity) as GameObject;
			if (instance.CompareTag ("Player")) {
				MainCamera.transform.parent = instance.transform;
				instance.transform.parent = actorHolder.transform;
			} else {
				instance.transform.parent = actorHolder.transform;
			}

		}
	}

		void Finish()
		{
			GameObject Controller = GameObject.FindWithTag ("GameController");
			var ControllerScript = Controller.GetComponent<GameManager> ();
			ControllerScript.SetActive ();


		}

	}



