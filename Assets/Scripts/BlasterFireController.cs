using UnityEngine;
using System.Collections;

public class BlasterFireController : MonoBehaviour 
{

	public Transform checkTop;

	public float firespeed = 15.0f;

	// Use this for initialization
	void Start () 
	{
		//checkTop = (Transform)GameObject.FindGameObjectWithTag("checkTop");
	}

	void Awake ()
	{
		gameObject.rigidbody2D.velocity = new Vector2(0, firespeed);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		Destroy(gameObject);
	}

}
