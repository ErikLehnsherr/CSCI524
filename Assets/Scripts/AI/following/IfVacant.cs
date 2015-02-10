using UnityEngine;
using System.Collections;


public class IfVacant : MonoBehaviour {
	public int vacant=0;
	//NetworkManager m;
	// Use this for initialization
	void Start () {
		vacant = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	[RPC]
	public void Occupied()
	{
		vacant = 1;
		//return vacant;
	}
	[RPC]
	public void Vacancy()
	{
		vacant = 0;
		//return vacant;
	}
	[RPC]
	public void ValueofTheSpace(spawnspot s,NetworkManager m)
	{
		m.GetComponent<PhotonView> ().RPC ("checkValue", PhotonTargets.All,s,vacant);
	}
	
}
