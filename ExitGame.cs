using UnityEngine;
using System.Collections;

public class ExitGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = Camera.main.ViewportToWorldPoint (new Vector3 (0.1f, 0.9f, 0.9f));
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
				Application.Quit();
			}
	}
}
}
