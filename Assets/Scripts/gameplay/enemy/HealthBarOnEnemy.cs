using UnityEngine;
using System.Collections;

public class HealthBarOnEnemy : MonoBehaviour {
	Vector2 vec;
	public Texture lifeBarBehindTex;
	public Texture lifeBarTex;
	float lifeRatio;
	public float lifeHeight = 10; 
	public float lifeBackgroundWidth=50;
	float lifeWidth;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(GetComponent<Health>()){
			lifeRatio = GetComponent<Health> ().getHealth ()/GetComponent<Health> ().HEALTH;
			lifeWidth=lifeRatio*lifeBackgroundWidth;
		}
		else{Debug.LogError("dont have health");}

	}
	void OnGUI()
	{
		//Debug.Log (GetComponent<Health> ().getHealth ()+" "+lifeRatio+" "+GetComponent<Health> ().HEALTH);
		if (lifeRatio > 0 && lifeRatio < 1) {
			vec=Camera.main.WorldToScreenPoint(transform.position);
			GUI.DrawTexture(new Rect(vec.x-lifeBackgroundWidth/2.0f,Screen.height-(vec.y+30),lifeBackgroundWidth,lifeHeight),lifeBarBehindTex,ScaleMode.StretchToFill);
			GUI.DrawTexture(new Rect(vec.x-lifeBackgroundWidth/2.0f,Screen.height-(vec.y+30),lifeWidth,lifeHeight),lifeBarTex,ScaleMode.StretchToFill);
			GUI.Label(new Rect(vec.x-lifeBackgroundWidth/2.0f,Screen.height-(vec.y+35),lifeBackgroundWidth,lifeHeight*2),//"hello");
			          GetComponent<Health> ().getHealth ()+"/"+GetComponent<Health> ().HEALTH);
		}
	}
}
