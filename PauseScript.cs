using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

	public GUITexture pauseGUI;
	public GUITexture pauseGUI1;
	public GUITexture pauseGUI2;
	public GUITexture pauseGUI3;
	public AudioClip pop;
	private bool pause;

	// Use this for initialization
	void Start () {
		DisableMenu ();
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
				pause = true;
				audio.PlayOneShot(pop, 0.5f);
			}
			if((collider2D == Physics2D.OverlapPoint(touchPos)) && (touch.phase == TouchPhase.Ended)){
				AudioListener.pause = true;
			}
		}
		if (pause == true) 
		{

			Time.timeScale = 0;

			pauseGUI.enabled = true;
			pauseGUI1.enabled = true;
			pauseGUI2.enabled = true;
			pauseGUI3.enabled = true;

			var count = Input.touchCount;

			for(int i = 0; i < count; i++) {
			//Vector3 wp = Camera.main.ScreenToViewportPoint(Input.GetTouch(i).position);
			Vector3 wp = Input.GetTouch(i).position;
				//Vector3 wp = new Vector3(op.x / Screen.width, op.y / Screen.height, 0) ;
			var touch = Input.GetTouch(i);

			if(pauseGUI1.HitTest(wp)){
				if(touch.phase == TouchPhase.Began){
						audio.PlayOneShot(pop, 0.5f);	
				}
				if((touch.phase == TouchPhase.Ended) && (PlayerPrefs.GetInt("mute") == 0)){
					DisableMenu();
					Time.timeScale = 1;
						AudioListener.pause = false;
				}
					if((touch.phase == TouchPhase.Ended) && (PlayerPrefs.GetInt("mute") == 1)){
						DisableMenu();
						Time.timeScale = 1;
						AudioListener.pause = true;
					}
			}
			if(pauseGUI2.HitTest(wp)){
					if(touch.phase == TouchPhase.Began){
						audio.PlayOneShot(pop, 0.5f);	
					}
					if((touch.phase == TouchPhase.Ended) && (PlayerPrefs.GetInt("mute") == 0 )){
					DisableMenu();
					Time.timeScale = 1;
						AudioListener.pause = false;
					Application.LoadLevel(Application.loadedLevel);
				}
					if((touch.phase == TouchPhase.Ended) && (PlayerPrefs.GetInt("mute") == 1 )){
						DisableMenu();
						Time.timeScale = 1;
						AudioListener.pause = true;
						Application.LoadLevel(Application.loadedLevel);
					}
			}
			if(pauseGUI3.HitTest(wp)){
					if(touch.phase == TouchPhase.Began){
						audio.PlayOneShot(pop, 0.5f);	
					}
					if((touch.phase == TouchPhase.Ended) && (PlayerPrefs.GetInt("mute") == 0)){
					DisableMenu();
					Time.timeScale = 1;
						AudioListener.pause = false;
					Application.LoadLevel(0);
				}
					if((touch.phase == TouchPhase.Ended) && (PlayerPrefs.GetInt("mute") == 1)){
						DisableMenu();
						Time.timeScale = 1;
						AudioListener.pause = true;
						Application.LoadLevel(0);
					}
				}
			}
		}
	}

	void DisableMenu() {
		pause = false;
		pauseGUI.enabled = false;
		pauseGUI1.enabled = false;
		pauseGUI2.enabled = false;
		pauseGUI3.enabled = false;
	}
}
