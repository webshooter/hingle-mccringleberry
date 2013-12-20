using UnityEngine;
using System.Collections;

public class ShipControl : MonoBehaviour 
{

	public Rigidbody2D blasters;
	public Transform blastersOrigin;

	public Transform checkTop;
	public Transform checkBottom;
	public Transform checkLeft;
	public Transform checkRight;

	public float speedHorizontal = 4.0f;
	public float speedForward    = 2.0f;
	public float speedBackward   = 1.0f;

	public float horizontalMoveForce = 250.0f;
	public float backwardMoveForce   = 200.0f;
	public float forwardMoveForce    = 250.0f;

	public float blasterFireSpeed = 12.0f;

	private bool checkTopHit    = false;
	private bool checkBottomHit = false;
	private bool checkLeftHit   = false;
	private bool checkRightHit  = false;

	private bool fireBlasters   = false;

	// Use this for initialization
	void Start () 
	{
		//
	}
	
	// Update is called once per frame
	void Update () 
	{

		// check bounds
		checkTopHit    = Physics2D.Linecast(transform.position, checkTop.position, 1 << LayerMask.NameToLayer("Walls"));
		checkBottomHit = Physics2D.Linecast(transform.position, checkBottom.position, 1 << LayerMask.NameToLayer("Walls"));

		if (Input.GetButtonDown("Fire1"))
		{
			fireBlasters = true;
		}

	}

	void FixedUpdate () 
	{

		// get horizontal input
		float h = Input.GetAxis("Horizontal");

		// get vertical input
		float v = Input.GetAxis("Vertical");

		if (fireBlasters)
		{
			FireBlasters();
		}

		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
//		if(h * gameObject.rigidbody2D.velocity.x < speedHorizontal)
//		{
//			
//			// ... add a force to the player.
//			gameObject.rigidbody2D.AddForce(Vector2.right * h * horizontalMoveForce);
//			
//		}

		// horizontal movement
		if (h > 0)
		{
			if (checkRightHit)
			{
				gameObject.rigidbody2D.velocity = new Vector2(0, gameObject.rigidbody2D.velocity.y);
			}
			else
			{
				if(h * gameObject.rigidbody2D.velocity.x < speedHorizontal)
				{
					
					// ... add a force to the player.
					gameObject.rigidbody2D.AddForce(Vector2.right * h * horizontalMoveForce);
					
				}
			}
		}
		else
		{
			if (checkLeftHit)
			{
				gameObject.rigidbody2D.velocity = new Vector2(0, gameObject.rigidbody2D.velocity.y);
			}
			else
			{
				if(h * gameObject.rigidbody2D.velocity.x < speedHorizontal)
				{
					
					// ... add a force to the player.
					gameObject.rigidbody2D.AddForce(Vector2.right * h * horizontalMoveForce);
					
				}
			}
		}

		// vertical movement
		if (v > 0)
		{

			// If the player's vertical velocity is greater than the maxSpeed...
			if(Mathf.Abs(gameObject.rigidbody2D.velocity.y) > speedForward)
			{
				
				// ... set the player's velocity to the maxSpeed in the -y axis.
				gameObject.rigidbody2D.velocity = new Vector2(gameObject.rigidbody2D.velocity.x, Mathf.Sign(gameObject.rigidbody2D.velocity.y) * speedForward);
				
			}

			if (checkTopHit)
			{
				gameObject.rigidbody2D.velocity = new Vector2(gameObject.rigidbody2D.velocity.x, 0);
			}
			else
			{
				if(v * gameObject.rigidbody2D.velocity.y < speedForward)
				{
					
					// ... add a force to the player.
					gameObject.rigidbody2D.AddForce(Vector2.up * v * forwardMoveForce);
					
				}
			}
		}
		else
		{

			// If the player's vertical velocity is greater than the maxSpeed...
			if(Mathf.Abs(gameObject.rigidbody2D.velocity.y) > speedBackward)
			{
				
				// ... set the player's velocity to the maxSpeed in the -y axis.
				gameObject.rigidbody2D.velocity = new Vector2(gameObject.rigidbody2D.velocity.x, Mathf.Sign(gameObject.rigidbody2D.velocity.y) * speedBackward);
				
			}

			if (checkBottomHit)
			{
				gameObject.rigidbody2D.velocity = new Vector2(gameObject.rigidbody2D.velocity.x, 0);
			}
			else
			{
				if(v * gameObject.rigidbody2D.velocity.y < speedBackward)
				{
					
					// ... add a force to the player.
					gameObject.rigidbody2D.AddForce(Vector2.up * v * backwardMoveForce);
					
				}
			}
		}

		// If the player's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(gameObject.rigidbody2D.velocity.x) > speedHorizontal)
		{

			// ... set the player's velocity to the maxSpeed in the x axis.
			gameObject.rigidbody2D.velocity = new Vector2(Mathf.Sign(gameObject.rigidbody2D.velocity.x) * speedHorizontal, gameObject.rigidbody2D.velocity.y);

		}



		if (h == 0)
		{
			gameObject.rigidbody2D.velocity = new Vector2(0, gameObject.rigidbody2D.velocity.y);
		}

		if (v == 0)
		{
			gameObject.rigidbody2D.velocity = new Vector2(gameObject.rigidbody2D.velocity.x, 0);
		}

	}

	void FireBlasters()
	{
		if (fireBlasters)
		{
			Rigidbody2D blastersInstance = Instantiate(blasters, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
			fireBlasters = false;
		}
	}

}
