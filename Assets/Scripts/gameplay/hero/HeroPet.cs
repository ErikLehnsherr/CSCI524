using UnityEngine;
using System.Collections;

public class HeroPet : MonoBehaviour {

    public GameObject pet;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CreatePet()
    {
		Vector3 newRandomPosition = new Vector3(Random.Range(-2.0F, 2.0F), 0, Random.Range(-2.0F, 2.0F));;
		Vector3 newSpawnposition = transform.position - newRandomPosition;
		GameObject newPet = (GameObject)PhotonNetwork.Instantiate("Golden_Retriever@sniff_3",newSpawnposition,transform.rotation,0);
        newPet.transform.parent = transform.parent;
        newPet.GetComponent<Team>().team = GetComponent<Team>().team; 
		newPet.AddComponent<BoidFlocking> ();
		GetComponent<BoidController>().add_pet(newPet);
    }
}
