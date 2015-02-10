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
	Vector3 targetDir;
	Vector3 newTargetPosition;
	Vector3 newDir;
	int denominator;
	
	
	void Awake ()
	{
		
		controller = GetComponent<CharacterController>();
		
		// Set random initial rotation
		heading = Random.Range(0, 360);
		transform.eulerAngles = new Vector3(0, heading, 0);
		
		closest = GameObject.FindGameObjectWithTag("Viking");;
		denominator = 80;
		
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
		center.Set (newPosition.x, newPosition.z);
		
		
		if(count%denominator == 0) {
			randOffset = Random.insideUnitCircle * 10 + center;
			count = 0;
		}
		
		newTargetPosition = new Vector3 (randOffset.x, transform.position.y, randOffset.y);
		targetDir = newTargetPosition - transform.position;
		
		if (Mathf.Abs (Vector3.Angle (targetDir, transform.forward)) > 120) {
			targetDir = transform.forward;
			newTargetPosition = transform.position;
			denominator = 1;
		} 
		else {
			denominator = 80;
		}
		
		Debug.Log ("angle =  " + Vector3.Angle(targetDir, transform.forward));
		
		float step = 6 * Time.deltaTime;
		newDir = Vector3.RotateTowards (transform.forward, targetDir, step, 0.0F);
		
		
		transform.rotation = Quaternion.LookRotation (newDir);
		transform.position = Vector3.MoveTowards (transform.position, newTargetPosition, step);
		
		count++;
	}
	
	
	
}




