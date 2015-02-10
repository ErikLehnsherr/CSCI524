using UnityEngine;
using System.Collections;

public class FeedState : MonoBehaviour {
	public float feed=0;
	public float loyal=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void BeFeed(float hp,Transform player)
	{
		//Debug.Log (gameObject+ " lost health "+hp);
		if (GetComponent<AnimalBase> ()== null) {
			Debug.LogError("no AnimalBase");		
		}
		hp -= GetComponent<AnimalBase> ().loyalty;
		if (hp < 0)
			hp = 0;
		feed+= hp;
		Debug.Log ("feed"+feed);


		if (feed >= GetComponent<Health> ().getHealth ()) {
			Debug.Log ("catch");
			GetComponent<CharacterFollow>().myTransform=transform;
			GetComponent<CharacterFollow>().enabled=true;
			tag=Tags.Pet;
			GetComponent<Health> ().heal(GetComponent<Health> ().getHealth ());
			GetComponent<WildMonsterAIStateMachine>().enabled=false;
		}
	}
}
