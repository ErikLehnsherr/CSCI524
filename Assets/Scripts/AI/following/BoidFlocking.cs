using UnityEngine;
using System.Collections.Generic;
public class BoidFlocking : MonoBehaviour
{
	private GameObject Controller;
//	private bool inited = false;
	private float Min;
	private float maxVelocity;
	//private float randomness;
//	private GameObject chasee;
//	private Vector3 relativePos;
//	private Vector3 coherency;
//	private Vector3 separation;

	Vector3 neightbor_center;
	List<GameObject> neighborhood = new List<GameObject>();
	//private List<GameObject> saliveMonsters;
	//public List<GameObject> unityGameObjects= new List<GameObject>();
	//selectedUnits = new List< GameObject >();

	public void add(GameObject a){
		//Debug.LogError ("BoidFlocking !!! add !!! before neighbor" + neighborhood.Count);
		neighborhood.Add(a);
		//Debug.LogError ("BoidFlocking !!! add !!! after neighbor" + neighborhood.Count);
	
	}
	
	void Start ()
	{	

		neightbor_center = new Vector3(0,0,0);
		neighborhood.Clear ();
		//unityGameObjects = new List<GameObject>();
		//StartCoroutine ("!!! BoidSteering");

	//	Debug.LogError ("!!! BoidFlocking_start()");
	//	BoidSteering ();
	}

	public void clearNeightbor(){

		neighborhood.Clear();
		neightbor_center = new Vector3 (0, 0, 0);
	
	}
	public void follow(Vector3 master_position){

		//transform.position += (master_position-transform.position)/1000; 
	}

	void Update ()
	{
		Vector3 separation = new Vector3(0,0,0);
		foreach(GameObject neighbor in neighborhood){

			Debug.LogError ("!!! neighbor" + neighbor.transform.position);
			neightbor_center +=((neighbor.transform.position)/neighborhood.Count);
			float distance_x =  transform.position.x- neighbor.transform.position.x ;
			float distance_z =  transform.position.z - neighbor.transform.position.z ;
			float distance = Mathf.Pow(distance_x*distance_x+distance_z*distance_z, 1/2);
			//float distance = neighbor.transform.position-transform.position;
			//float se_f = Vector3.Distance(transform.position,neighbor.transform.position);

//			if(distance<5){
				separation = separation+ new Vector3 (distance_x/1000, 0, distance_z/1000);

//			}
			//separation += distance / distance.sqrMagnitude;
			float follow_factor = Random.Range(1,10)/10;
			transform.GetComponent<CharacterFollow>().getFollow(follow_factor);
		};

		transform.position += (neightbor_center- transform.position)/10000; 
		transform.position += separation;
		//Debug.LogError ("!!! neightbor_center" + neightbor_center);

	}
	void cal(){




	}
	void BoidSteering ()
	{	

		//for each 
	//	Debug.Log ("!!!!!!!! BoidSteering_BoidSteering()");
		/*
		while (true)
		{
			if (inited)
			{


				rigidbody.velocity = rigidbody.velocity + Calc (); //* Time.deltaTime;
				
				// enforce minimum and maximum speeds for the boids
				float speed = rigidbody.velocity.magnitude;
				if (speed > maxVelocity)
				{
					rigidbody.velocity = rigidbody.velocity.normalized * maxVelocity;
				}
				else if (speed < minVelocity)
				{
					rigidbody.velocity = rigidbody.velocity.normalized * minVelocity;
				}
			}
			
			float waitTime = Random.Range(-1f, 1f);
			yield return new WaitForSeconds (waitTime);
		}*/
	}
	
	private void Calc ()
	{
		/*
		Debug.Log ("!!! BoidFlocking_Calc()");
		float x = (float) (Random.value * 0.5);
		float y = (float) (Random.value * 0.5);
		float z = (float) (Random.value * 0.5);

		Vector3 randomize = new Vector3 (x, 0 ,z);
		
		randomize.Normalize();
		BoidController boidController = Controller.GetComponent<BoidController>();
		Vector3 flockCenter = boidController.flockCenter;
		Vector3 flockVelocity = boidController.flockVelocity;
		Vector3 follow = chasee.transform.localPosition;
		Debug.Log ("!!! BoidFlocking_Calc()");
		flockCenter = flockCenter - transform.localPosition;
		
		flockVelocity = flockVelocity - rigidbody.velocity;
		follow = follow - transform.localPosition;
		Debug.LogError ("!!! Calc () flockCenter = " + flockCenter + " flockVelocity =  " + flockVelocity + " follow = " + follow);
		return (flockCenter + flockVelocity + follow * 10  + randomize * randomness);
	*/
	}
	
	public void SetController (GameObject theController)
	{	/*
		Controller = theController;
		BoidController boidController = Controller.GetComponent<BoidController>();
		minVelocity = boidController.minVelocity;
		maxVelocity = boidController.maxVelocity;
		randomness = boidController.randomness;
		chasee = boidController.chasee;
		inited = true;*/
	}
}