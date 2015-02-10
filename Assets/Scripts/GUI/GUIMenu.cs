using UnityEngine;
using System.Collections;

public class GUIMenu : MonoBehaviour {
	
	void OnGUI () {

		// Create rect in screen space and return - does not account for camera perspective
		//return new Rect(origin.x, Screen.height - origin.y, extent.x - origin.x, origin.y - extent.y);
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(		GUI.Button(new Rect(Screen.width / 2-50 , Screen.height / 2+50,100, 30),"Multi Player")) {
			Application.LoadLevel("test_tryFog");
		}
		if(		GUI.Button(new Rect(Screen.width / 2+160 , Screen.height / 2+50,100, 30),"Exit")) {
			//	Application.LoadLevel(1);
		}
		if(		GUI.Button(new Rect(Screen.width / 2-260, Screen.height / 2+50,100, 30),"Single Player")) {
			//	Application.LoadLevel(1);
		}
	}
}

