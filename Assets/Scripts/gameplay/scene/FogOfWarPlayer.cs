using UnityEngine;
using System.Collections;

public class FogOfWarPlayer : MonoBehaviour {
	
	private Transform FogOfWarPlane;
	private static int NUMBER = 1;
	private int Number;
	
	// Use this for initialization
	void Start () {
		if(GameObject.FindGameObjectWithTag ("fogPlane")!=null)
		FogOfWarPlane = GameObject.FindGameObjectWithTag ("fogPlane").transform;
		Number = NUMBER;
		NUMBER++;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 screenPos = Camera.mainCamera.WorldToScreenPoint(transform.position);
		Ray rayToPlayerPos = Camera.main.ScreenPointToRay(screenPos);
		int layermask = (int)(1<<8);
		RaycastHit hit;
		if(Physics.Raycast(rayToPlayerPos, out hit)) {
			if(FogOfWarPlane!=null)
			FogOfWarPlane.GetComponent<Renderer>().material.SetVector("_Player" + Number.ToString() +"_Pos", hit.point);

		}
		//FogOfWarPlane.GetComponent<Renderer>().material.SetVector("_Player" + Number.ToString() +"_Pos", transform.position);
	}
}