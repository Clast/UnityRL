using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {

	public LayerMask Blocklayer;
	private BoxCollider2D boxCollider;
	private Rigidbody2D rgdBody;
	public int speed= 100;
	RaycastHit2D hit;
	public int health = 100;
	public int attack = 50;


	// Use this for initialization
	protected virtual void Start () 
	{



	}

	protected virtual void Awake () 
	{
		boxCollider = GetComponent <BoxCollider2D> (); 
		rgdBody = GetComponent <Rigidbody2D> ();
		speed = 10;
		Blocklayer = 1 << 8;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	protected bool canMove(int xDir, int yDir, out RaycastHit2D hit) //True if able to move, pass hit by reference
	{

		
		Vector2 start = transform.position; 
		Vector2 end = start + new Vector2 (xDir, yDir);
		boxCollider.enabled = false;
		hit = Physics2D.Linecast (start, end, Blocklayer); // hit will store whatever (if anything) is hit on the blocking layer
		boxCollider.enabled = true;

		if (hit.transform == null) 
		{

			return true;
			
		} 

		//Debug.Log ("Hit something" + hit.GetType ());
		return false;
		
	}
	
	public void Move (int xDir, int yDir)
	{
		Vector2 start = transform.position;
		Vector2 destination = start + new Vector2(xDir, yDir);
		transform.position = destination;
	}

	public virtual void Act ()
	{
			int x = 0;
			int y = 0;
			bool done = false;

			while (done == false) 
		{
			x = Random.Range (-1, 2);
			y = Random.Range (-1, 2);
			if (canMove (x, y, out hit)) //Prevent monster from walking into player space
			{
				//Move (x, y);
				done = true;
			}

			
		}


	}


}
