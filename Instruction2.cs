﻿using UnityEngine;
using System.Collections;

public class Instruction2 : MonoBehaviour {

	public AudioClip pop;
	// Use this for initialization
	void Start () {
		transform.position = Camera.main.ViewportToWorldPoint (new Vector3 (0.5f, 0.1f, 1));
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0)
		{
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			var touch = Input.GetTouch(0);
			Vector2 touchPos = new Vector2(wp.x, wp.y);
			if ((collider2D == Physics2D.OverlapPoint(touchPos)) && (touch.phase == TouchPhase.Ended))
			{
				audio.PlayOneShot(pop, 0.5f);
				Application.LoadLevel(5);
			}
		}
	}
}
