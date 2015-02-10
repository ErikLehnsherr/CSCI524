using UnityEngine;
using System.Collections.Generic;

public class BoidController : MonoBehaviour
{
	public float minVelocity = 0;
	public float maxVelocity = 2;
	public float randomness = 1;
	public int flockSize ;
	public GameObject[] pets;
	public GameObject chasee;
	List<GameObject> boids = new List<GameObject>();
	//public GameObject[] boids;
	public void add_pet(GameObject newPet)
	{			

		//Debug.LogError ("!!!!! add_pet | boids.Length = first " + boids.Count + "flockSize = "+ flockSize );
		boids.Add(newPet);
		//Debug.LogError ("!!!!! add_pet | boids.Length = " + boids.Count + "flockSize = "+ flockSize );
		/*
		if (boids.Length == 0) {
			Vector3 newPosition = new Vector3(transform.localPosition.x-2,0,transform.localPosition.z);
			return newPosition;

		}else{




		}

		/*
		Debug.LogError ("!!!!! add_pet Before| flockSize = " + flockSize);
		flockSize = flockSize + 1;
		Debug.LogError ("!!!!! add_pet After | flockSize = " + flockSize);
		Vector3 position_pet = newPet.transform.localPosition;
		Debug.LogError ("!!!!! add_pet new pet position =" + position_pet);
		boids[flockSize] = newPet;
	*/
		//Update(newPet);
	}


	
	public Vector3 flockCenter;
	public Vector3 flockVelocity;
	

	
	void Start()
	{	
		//flockSize = 0;
		//Debug.Log ("!!!!! flockSize="+ flockSize);
	//	boids = new GameObject[12];
		//for (var i=0; i<flockSize; i++)
		//{
	//	GameObject boid = GameObject.FindWithTag("pet");
	//	//Vector3 position = new Vector3 (
		//		Random.value * collider.bounds.size.x,
		//		Random.value * collider.bounds.size.y,
		///		Random.value * collider.bounds.size.z
		//		) - collider.bounds.extents;
			
			//GameObject boid = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
			//GameObject boid = PhotonNetwork.Instantiate(prefab, transform.position, transform.rotation,1) as GameObject;
		
	//	boid.transform.parent = transform;
		//boid.transform.localPosition = position;
	//	boid.GetComponent<BoidFlocking>().SetController (gameObject);
	//	boids[0] = boid;
	//	//}
	}
	
	void Update ()
	{

		GameObject[] boids_arr = boids.ToArray();
		//boids = GameObject.FindGameObjectsWithTag ("pet");
		/*
		if (boids.Count > 1) {


			Debug.LogError ("!!!!! Update() | boids.Count = " + boids.Count);
			foreach(GameObject boid in boids)

				int self = boids.FindIndex(boid);
				foreach(GameObject boid in boids)
					int boidIndex = boids.FindIndex(boid);
					if(!(boidIndex-self).Equals(0)){
					// compare distance and add into neighbor
						


					}

			}*/
		for (int i =0; i<boids_arr.Length; i++) {


			boids_arr[i].GetComponent<BoidFlocking>().clearNeightbor();
			for (int j =0; j<boids_arr.Length; j++) {
				if(i!=j){
				float distance = Mathf.Pow (((boids_arr[i].transform.position.x - boids_arr[j].transform.position.x) *
				                             (boids_arr[i].transform.position.x - boids_arr[j].transform.position.x) +
				                             (boids_arr[i].transform.position.z - boids_arr[j].transform.position.z) *
				                             (boids_arr[i].transform.position.z - boids_arr[j].transform.position.z)), 1/2);

					if ((distance <= 2)) {
					//	Debug.LogError ("!!!!! ADDDDDDDDDD istance<=20 distance==== " + distance);
					//	Debug.LogError ("!!!!! check boids[i]" + boids [i] + " i = " + i);
					//	Debug.LogError ("!!!!! check boids[j]" + boids [j] + " j = " + j);
						boids_arr[i].GetComponent<BoidFlocking> ().add (boids_arr[j]);
						boids_arr[i].GetComponent<BoidFlocking> ().follow (transform.position);
						//Debug.LogError ("!!!!! check boids[j]" + boids [j] + " j = " + j);
					}
				}
			}
		}
		/*

		if(newPet.rigidbody.detectCollisions){

			Vector3 oldPosition = newPet.transform.localPosition;
			Vector3 newPosition = oldPosition + new Vector3 (Random.Range(2,4),0,Random.Range(2,4));
			newPet.transform.localPosition=  newPosition; 
			Debug.LogError("!!!!! detectCollisions | oldPosition = "+ oldPosition + " |newPosition = " + newPosition);
		}
		/*
		if (flockSize != 0) {
			Vector3 theCenter = Vector3.zero;
			Vector3 theVelocity = Vector3.zero;
			for (var i=0; i<flockSize; i++) {
			//foreach (GameObject boid in boids)
				if (boids [i] != null) {
					Debug.Log ("!!!!Update i = " + i + " / boids[i].transform.localPosition = " + boids [i].transform.localPosition + " /boids[i].rigidbody.velocity  = " + boids [i].rigidbody.velocity);
					theCenter = theCenter + boids [i].transform.localPosition;
					theVelocity = theVelocity + boids [i].rigidbody.velocity;
				}
			}


			flockCenter = theCenter / (flockSize);
			flockVelocity = theVelocity / (flockSize);
			Debug.LogError ("!!!!flockCenter " + flockCenter + " /flockVelocity  = " + flockVelocity + "/flockSize  =" + flockSize);
		}*/
	}
}