using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

	public GameObject Platform_1;
	public GameObject Platform_2;
	public int maxplatcount;
	public float MinPlatformHeight;
	public float MaxPlatformHeight;
	public float MinPlatformDistance;
	public float MaxPlatformDistance;

	private GameObject Deadplatform;
	private float RandomXDistance;
	private float RandomYDistance;
	private int platcount;
	private int n;
	private bool afterjump;

	// Use this for initialization
	void Start () 
	{
		GameObject Initialplatform = Instantiate (Platform_1, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
		Initialplatform.name = "Platform 1";
		platcount = 1;
		n = 0;
		afterjump = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float Platformstyle = Random.Range (1, 4);
		if ((Platformstyle > 2) && (platcount < maxplatcount)) 
		{
			do_platform1();	
			afterjump = false;
		}
		if ((Platformstyle <= 2) && (platcount < maxplatcount))
		{
			do_platform2();
			afterjump = true;
		}
		Deadplatform = GameObject.Find ("Platform " + (1 + n * 10));

		if ((platcount == maxplatcount) && (Deadplatform == null))
		{
			maxplatcount += 10;
			n++;
		}
	}

	// Creating Random flat platform
	void do_platform1()
	{
		GameObject previousPlatform = GameObject.Find ("Platform " + platcount);
		GameObject platformGenerated = Instantiate (Platform_1, transform.position, transform.rotation) as GameObject;
		
		platformGenerated.transform.localPosition = previousPlatform.transform.localPosition;

		Debug.Log (platformGenerated.transform.position.y);
		if (platformGenerated.transform.position.y < -5) 
		{
			afterjump = true;	
		}
		if (platformGenerated.transform.position.y > 5) 
		{
			afterjump = false;
		}

		platformGenerated.transform.Translate (previousPlatform.renderer.bounds.extents.x + platformGenerated.renderer.bounds.extents.x, 0, 0);

		if (afterjump == true) 
		{
			RandomYDistance = Random.Range (0, MaxPlatformHeight);
			RandomXDistance = Random.Range (MinPlatformDistance, MaxPlatformDistance);
		} 
		if (afterjump == false)
		{
			RandomYDistance = Random.Range (MinPlatformHeight, 0);
			RandomXDistance = 0;
		}

		platformGenerated.transform.Translate (RandomXDistance, RandomYDistance, 0);

		platcount++;
		platformGenerated.name = "Platform " + platcount;
	}

	// Creating Random jump platform
	void do_platform2()
	{
		GameObject previousPlatform = GameObject.Find ("Platform " + platcount);
		GameObject platformGenerated = Instantiate (Platform_2, transform.position, transform.rotation) as GameObject;
		
		platformGenerated.transform.localPosition = previousPlatform.transform.localPosition;

		Debug.Log (platformGenerated.transform.position.y);
		if (platformGenerated.transform.position.y < -5) 
		{
			afterjump = true;	
		}
		if (platformGenerated.transform.position.y > 5) 
		{
			afterjump = false;
		}

		platformGenerated.transform.Translate (previousPlatform.renderer.bounds.extents.x + platformGenerated.renderer.bounds.extents.x, 0, 0);
		
		if (afterjump == true) 
		{
			RandomYDistance = Random.Range (0, MaxPlatformHeight);
			RandomXDistance = Random.Range (MinPlatformDistance, MaxPlatformDistance);
		} 
		if (afterjump == false)
		{
			RandomYDistance = Random.Range (MinPlatformHeight, 0);
			RandomXDistance = 0;
		}
		
		platformGenerated.transform.Translate (RandomXDistance, RandomYDistance, 0);
		
		platcount++;
		platformGenerated.name = "Platform " + platcount;
	}
}
