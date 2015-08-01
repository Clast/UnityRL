using UnityEngine;
using System.Collections;

public class Player : Actor 
{
	RaycastHit2D hit;
//	bool playersturn = false;
	bool canmove = false;
	private GameObject Manager;
	private GameManager ManagerScript;
	// Use this for initialization
	protected override void Start () 
	{
		base.Awake();
		Manager = GameObject.FindWithTag ("GameController");
		ManagerScript = Manager.GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!ManagerScript.playersturn)
		{
			return;
		}
		if (Input.GetButtonDown("Up")) //Up
		{
			
			canmove = base.canMove(0,1, out hit);
			if (canmove == true)
			{
				Move(0,1);
				ManagerScript.playersturn = false;
			}
			Debug.Log (hit.rigidbody);
		}
		if (Input.GetButtonDown("Down"))//Down
		{
			canmove = canMove(0,-1,out hit);
			if (canmove == true)
			{
				Move(0,-1);
				ManagerScript.playersturn = false;
			}
			
		}
		if (Input.GetButtonDown("Left"))//Left
		{
			canmove = canMove(-1,0,out hit);
			if (canmove == true)
			{
				Move(-1,0);
				ManagerScript.playersturn = false;
			}
		}
		
		if (Input.GetButtonDown("Right"))//Right
		{
			canmove = canMove(1,0,out hit);
			if (canmove == true)
			{
				Move(1,0);
				ManagerScript.playersturn = false;
			}
		}


	 }

	public override void Act()
	{

	}
}

