using UnityEngine;
using System.Collections;

public class Player : Actor 
{
	RaycastHit2D hit;
	bool playersturn = true;
	bool canmove = false;

	// Use this for initialization
	protected override void Start () 
	{
		base.Start();
	}
	
	// Update is called once per frame
	void Update () 
	{



	 }

	public override void Act()
	{
		while (playersturn == true)
		{
			if (Input.GetButtonDown("Up")) //Up
			{
				
				canmove = base.canMove(0,1, out hit);
				if (canmove == true)
				{
					Move(0,1);
				}
			}
			if (Input.GetButtonDown("Down"))//Down
			{
				canmove = canMove(0,-1,out hit);
				if (canmove == true)
				{
					Move(0,-1);
				}
				
			}
			if (Input.GetButtonDown("Left"))//Left
			{
				canmove = canMove(-1,0,out hit);
				if (canmove == true)
				{
					Move(-1,0);
				}
			}
			
			if (Input.GetButtonDown("Right"))//Right
			{
				canmove = canMove(1,0,out hit);
				if (canmove == true)
				{
					Move(1,0);
				}
			}
		}
	}
}

