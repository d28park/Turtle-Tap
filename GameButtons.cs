using UnityEngine;
using System.Collections;

public class GameButtons : MonoBehaviour {

	public GameObject Player;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		Vector3 topRight = new Vector3(Camera.main.pixelWidth * 0.84f, Camera.main.pixelHeight * 0.9f, 2.0f);
		transform.position = Camera.main.ScreenToWorldPoint(topRight);
		offset = transform.position;
	}

	void LateUpdate () {
		transform.position = offset + Player.transform.position;
	}
}
