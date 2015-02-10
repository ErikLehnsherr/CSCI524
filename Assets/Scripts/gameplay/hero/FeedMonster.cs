using UnityEngine;
using System.Collections;

public class FeedMonster : MonoBehaviour {
	public GameObject feedee;
	public float feedBase=5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void FeedSimple(GameObject obj)//for minions
	{
		feedee = obj;
		doFeed (feedBase);
		
	}
	void doFeed()
	{
		Debug.Log ("really feed");
	}

	void doFeed(float feedNum)
	{
		if (tag == Tags.Player) {
			if(GetComponent<HeroBase>()==null)
				Debug.LogError("no heroBase");

		}
		feedee.GetComponent<FeedState>().BeFeed(feedNum,transform);//need to consider attackee's armor later

		//there should be animation;
		//transform.rigidbody.AddForce(new Vector3(0, 1, 0));
		
		
	}
}
