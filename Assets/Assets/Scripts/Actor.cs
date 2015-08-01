using UnityEngine;
using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {

	public LayerMask Blocklayer;
	private BoxCollider2D boxCollider;
	private Rigidbody2D rgdBody;
	public int energy = 10;
	public int speed= 100;


	// Use this for initialization
	protected virtual void Start () 
	{
		boxCollider = GetComponent <BoxCollider2D> (); 
		rgdBody = GetComponent <Rigidbody2D> ();
		energy = 100;
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
			Debug.Log(hit.transform);
			return true;
			
		} 
		Debug.Log ("Hit something" + hit.GetType ());
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
		Vector2 start = transform.position;
			int x = Random.Range(-1,2);
			int y = Random.Range(-1,2);
			Move(x,y);
			Debug.Log ("Moving" + x + y);

	}

	public void Tick ()
	{
		energy = energy + speed;
		//Debug.Log (energy);
	}
}
