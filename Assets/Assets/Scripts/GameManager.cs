using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public int turns;
	public GameObject active;
	public Transform actors;
	private BoardManager boardscript;
	public Component actorscript;
	public GameObject whatisthis;
	//private GameObject[] Actors;
	// Use this for initialization
	void Start () {
		boardscript = GetComponent <BoardManager>();
		boardscript.enabled = true;

	}
	
	// Update is called once per frame
	void Update () 
	{
		GameLoop();

	}

	public void SetActive() //This needs to be called after the setup is done on the board BY the board object.
	{
		active = GameObject.FindWithTag ("Active Level");
		actors = active.transform.Find ("Actors");

	}

	private void GameLoop()
	{


		foreach (Transform child in actors.transform)
		{
			actorscript = child.gameObject.GetComponent<Actor>();
			//Debug.Log (actorscript.Energy);

		}
	}
}

