using UnityEngine;
using System.Collections;

public class RestartScript : MonoBehaviour {

	public GUIText Score;
	public GUIText HScore;
	public AudioClip pop;
	private string Newhigh;
	// Use this for initialization
	void Start () {
		transform.position = Camera.main.ViewportToWorldPoint (new Vector3 (0.3f, 0.15f, 1));

		Newhigh = "";
		Score.text = PlayerPrefs.GetInt("CurrentScore").ToString();
		if(PlayerPrefs.GetInt("CurrentScore") > PlayerPrefs.GetInt("HighScore",0))
		{
			PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("CurrentScore"));
			Newhigh = " New!";
		}
		HScore.text = PlayerPrefs.GetInt ("HighScore").ToString() + Newhigh;
	
		Score.transform.position = new Vector3 (0.6f, 0.75f, 2);
		HScore.transform.position = new Vector3 (0.3f, 0.5f, 2);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0)
		{
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			var touch = Input.GetTouch(0);
			Vector2 touchPos = new Vector2(wp.x, wp.y);
			if ((collider2D == Physics2D.OverlapPoint(touchPos)) && (touch.phase == TouchPhase.Began))
			{
				audio.PlayOneShot(pop, 0.5f);
			}
			if ((collider2D == Physics2D.OverlapPoint(touchPos)) && (touch.phase == TouchPhase.Ended))
			{
				Application.LoadLevel(1);	
			}
		}
	}
}
