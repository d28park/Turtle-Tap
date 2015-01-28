using UnityEngine;
using System.Collections;

public class BackGroundScript : MonoBehaviour {

	private Vector3 backPos;
	public float width;
	public float height = 0f;
	private float X;
	private float Y;

	void OnBecameInvisible()
	{
		Debug.Log ("Past");
		//calculate current position
		backPos = gameObject.transform.position;
		//calculate new position
		print (backPos);
		X = backPos.x + width*2;
		Y = backPos.y + height*2;
		//move to new position when invisible
		gameObject.transform.position = new Vector3 (X, Y, 0f);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
