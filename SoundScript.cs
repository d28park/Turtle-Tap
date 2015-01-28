using UnityEngine;
using System.Collections;

public class SoundScript : MonoBehaviour {

	public Sprite soundon;
	public Sprite soundoff;
	public AudioClip pop;
	private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		sprite = gameObject.GetComponent<SpriteRenderer>();
		if (PlayerPrefs.GetInt ("mute") == 0) {
			sprite.sprite = soundon;		
		}
		if (PlayerPrefs.GetInt ("mute") == 1) {
			sprite.sprite = soundoff;		
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		sprite = gameObject.GetComponent<SpriteRenderer>();
		if (Input.touchCount > 0)
		{
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			var touch = Input.GetTouch(0);
			Vector2 touchPos = new Vector2(wp.x, wp.y);
			if ((collider2D == Physics2D.OverlapPoint(touchPos)) && (touch.phase == TouchPhase.Ended))
			{
				//soundon.transform.Translate(new Vector3(0,0,1));
				//soundoff.transform.Translate(new Vector3(0,0,-1));
				//if(sprite.sprite == soundon){
				//	audio.PlayOneShot(pop, 0.5f);
				//	Debug.Log(sprite.sprite);
				//	sprite.sprite = soundoff;
					PlayerPrefs.SetInt("mute", 1);
					AudioListener.pause = true;
				//}
				if(sprite.sprite == soundoff){
					audio.PlayOneShot(pop, 0.5f);
					sprite.sprite = soundon;
					PlayerPrefs.SetInt("mute", 0);
					AudioListener.pause = false;
				}
			}
	}
}
}