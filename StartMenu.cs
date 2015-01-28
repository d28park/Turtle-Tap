using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	public AudioClip pop;
	private bool touched;
	// Use this for initialization
	void Start () {
		touched = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount == 1)
		{
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			var touch = Input.GetTouch(0);
			Vector2 touchPos = new Vector2(wp.x, wp.y);

			if ((collider2D == Physics2D.OverlapPoint(touchPos)) && (touch.phase == TouchPhase.Ended))
			{
				audio.PlayOneShot(pop, 0.5f);
				Application.LoadLevel(3);
			}
		}
	}
}
