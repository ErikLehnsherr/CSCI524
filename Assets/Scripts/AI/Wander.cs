using UnityEngine;
using System.Collections;

/// <summary>
/// Creates wandering behaviour for a CharacterController.
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class Wander : MonoBehaviour
{
	public float speed = 5;
	public float directionChangeInterval = 1;
	public float maxHeadingChange = 180;
	public int count = 0;

	CharacterController controller;
	float heading;
	Vector3 targetRotation;
	public GameObject closest;
	public Vector2 center;
	Vector2 randOffset;
	Vector3 newPosition;

	void Awake ()
	{
		
		controller = GetComponent<CharacterController>();
		
		// Set random initial rotation
		heading = Random.Range(0, 360);
		transform.eulerAngles = new Vector3(0, heading, 0);
		
		//StartCoroutine(NewHeading());
		closest = GameObject.FindGameObjectWithTag("Viking");;
		
		Debug.Log ("hihiJoseph");
	}
	
	void Update ()
	{

		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				newPosition = hit.point;
				Debug.Log("newPosition = " + newPosition);
			}
		}

		

		speed = 15;
		//center.Set (closest.transform.position.x, closest.transform.position.z);
		center.Set (newPosition.x, newPosition.z);

					
			if(count%250 == 0) {
				randOffset = Random.insideUnitCircle * 10 + center;
				count = 0;
			}
			//Vector3 newTargetPosition = new Vector3 (closest.transform.position.x, transform.position.y, closest.transform.position.z);
			Vector3 newTargetPosition = new Vector3 (randOffset.x, transform.position.y, randOffset.y);

			Vector3 targetDir = newTargetPosition - transform.position;
			float step = 2 * Time.deltaTime;
			Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, step, 0.0F);
			
			
			transform.rotation = Quaternion.LookRotation (newDir);
			//transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (newDir), 3 * Time.deltaTime);
		transform.position = Vector3.MoveTowards (transform.position, newTargetPosition, step);
			
		count++;
	}
	


}




