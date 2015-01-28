using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public GUIText Scorecount;
	public float speed;
	public float jumpspeed;
	public float uprotationspeed;
	public float downrotation;
	public float playerrotation;
	public float wormup;
	private GameObject Pastplatform;
	public AudioClip rolling;
	public AudioClip squee;
	public AudioClip thud;
	public Sprite sprite1;
	public Sprite sprite2;
	private int counter;
	private int platcount;
	private float myspeed;
	private SpriteRenderer spriteRenderer;
	
	void Start () 
	{
		counter = 0;
		ScoreUpdate ();
		spriteRenderer = GetComponent<SpriteRenderer>();
		//transform.Translate (1.0f, 0.0f, 0.0f, Space.World);
	}
	
	void FixedUpdate () 
	{
		/*myspeed = rigidbody2D.velocity.magnitude;
		if (myspeed < speed) 
		{
			rigidbody2D.AddForce(Vector2.right * 1.1f);
		}*/
		
		//transform.Translate (speed * Time.deltaTime, 0, 0, Space.World);
		
		rigidbody2D.velocity = 15.0f * (rigidbody2D.velocity.normalized);
		
		if (Input.GetButtonDown ("Fire1")) 
		{
			//rigidbody2D.AddTorque(playerrotation, ForceMode2D.Impulse);
			//rigidbody2D.AddTorque(-2 * playerrotation, ForceMode2D.Force);
			transform.Rotate(0, 0, playerrotation);
			if(spriteRenderer.sprite == sprite1){
				spriteRenderer.sprite = sprite2;}
			//audio.PlayOneShot(whiff);
		}
		if (Input.GetButtonUp ("Fire1")) 
		{
				spriteRenderer.sprite = sprite1;
		}

		rigidbody2D.angularVelocity *= 0.9f;
		// For Android 
		if (Input.touchCount > 0) {
			var touch = Input.GetTouch(0);	
				transform.Rotate(0,0,playerrotation);
			print(touch.position);
	
			//if (touch.position.x > Screen.width/2) {			rigidbody2D.AddTorque(-playerrotation, ForceMode2D.Impulse);
			//	rigidbody2D.AddTorque(2 * playerrotation, ForceMode2D.Force);}
		}
		
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if ((other.gameObject.tag == "Finish") || (other.gameObject.tag == "background"))
		{
			int bestscore = PlayerPrefs.GetInt("Highscore", 0);
			PlayerPrefs.SetInt("CurrentScore", counter);
			Application.LoadLevel(2);
		}
		
		if (other.gameObject.tag == "platcount") 
		{
			Debug.Log("Hit" + counter);
			counter++;
			ScoreUpdate();
			Destroy(other.gameObject);
			if (counter > 5);
			{
				platcount = counter - 5;
				Pastplatform = GameObject.Find ("Platform " + platcount);
				Destroy(Pastplatform);
			}
		}
		if (other.gameObject.tag == "worm") 
		{
			Debug.Log("worm");
			other.gameObject.transform.Translate(0, wormup, 0);
			transform.Translate(0,3,0, Space.World);

			//rigidbody2D.AddForce(Vector2.up * jumpspeed, ForceMode2D.Impulse);
			
			rigidbody2D.AddTorque(uprotationspeed, ForceMode2D.Impulse);

			//rigidbody2D.AddTorque(-2 * uprotationspeed, ForceMode2D.Force);
			
			//transform.rotation = Quaternion.AngleAxis(30f, transform.forward) * transform.rotation;
			//Quaternion q = Quaternion.AngleAxis(90f, transform.forward);
			//transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * uprotationspeed);
			
			Destroy(other.gameObject.collider2D);
			audio.PlayOneShot(squee);
		}
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "jumpplat") 
		{
			audio.PlayOneShot(rolling, 0.03f);
			audio.PlayOneShot(thud, 0.05f);
		}
	}

	void ScoreUpdate() 
	{
		Scorecount.text = counter.ToString();
	}
}