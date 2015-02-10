using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	
	public  GameObject StandByCamera;
	spawnspot[] spawnstuff;
	Vector3 dog=new Vector3(-2,-2,0);
	private int maxPlayer =1;
	private string maxPlayerString = "1";
	//Declare String for room lobby names
	private string roomName = "Room02";
	//Declare for room status.....
	private string roomStatus = "";
	private int value=0;
	private int[]vacancy;
	private string[] playerName;
 	//Declare list of Room array.
	private Room[] game;
	private int x=0;
	private int x1=0;
	private Vector2 scrollPosition;

	// Use this for initialization
	void Start () {
		spawnstuff=GameObject.FindObjectsOfType<spawnspot>();
		playerName=new string[20];
		for (int i=0; i<20; i++)
			playerName [i] = "My Name";
		//vacancy=
		
		Connect ();
	}
	void Connect()
	{
		PhotonNetwork.ConnectUsingSettings ("1.0.0");
		//PhotonNetwork.offlineMode="True";
	}
	void OnGUI()
	{
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
		//if (GUI.Button(new Rect ( 100,100,100,100), "Disconnect"))
			//PhotonNetwork.LeaveRoom	();
	
		if (PhotonNetwork.insideLobby == true) {
			Debug.Log ("Room name"+roomName);
						//Display the lobby connection list and room creation.
						GUI.Box (new Rect (Screen.width / 2.5f, Screen.height/2-200, 200, 350), "");
						GUILayout.BeginArea (new Rect (Screen.width / 2.5f, Screen.height/2-200, 200, 350));
						GUI.color = Color.red;
						GUILayout.Box ("Lobby");
						GUI.color = Color.white;
			x1 = PhotonNetwork.playerList.Length;
			if (x1 == null)
				x1 = 0;
			GUILayout.Label ("Player Name:");
			playerName[x1] = GUILayout.TextField(playerName[x1]);

			Debug.Log("x1=" +x1);
			Debug.Log("Player name="+playerName[x1]);
		
						GUILayout.Label ("Room Name:");
			roomName = GUILayout.TextField(roomName); //For network room name ask and recieve
						GUILayout.Label ("Max Amount of player 1-20:");
						maxPlayerString = GUILayout.TextField (maxPlayerString, 2); //How man players with a max character set of 2 allowing no more then 2 digit player size.
		
						if (maxPlayerString != "") { // if there is a character of max players
			
								maxPlayer = int.Parse (maxPlayerString); // parse the max player text field into a string.
			
								if (maxPlayer > 20)
										maxPlayer = 20; // if I enter above 20 reset the max to 20 .
								if (maxPlayer == 0)
										maxPlayer = 1; // if i'm below 1 reset min of 1
			
						} else {
								maxPlayer = 1; // 1
						}
		
						if (GUILayout.Button ("Create Room")) {
			
								if (roomName != "" && maxPlayer > 0) { // if the room name has a name and max players are larger then 0
										//check1 = 1;
										PhotonNetwork.CreateRoom(roomName,true,true,maxPlayer); // then create a photon room visible , and open with the maxplayers provide by user.
				
								}
						}
		
						GUILayout.Space (20);
						GUI.color = Color.red;
						GUILayout.Box ("Game Rooms");
						GUI.color = Color.white;
						GUILayout.Space (20);
		
						scrollPosition = GUILayout.BeginScrollView (scrollPosition, false, true, GUILayout.Width (200), GUILayout.Height (70));
		
						foreach (RoomInfo game in PhotonNetwork.GetRoomList()) { // Each RoomInfo "game" in the amount of games created "rooms" display the fallowing.
			
								GUI.color = Color.green;
								GUILayout.Box (game.name + " " + game.playerCount + "/" + game.maxPlayers); //Thus we are in a for loop of games rooms display the game.name provide assigned above, playercount, and max players provided. EX 2/20
								GUI.color = Color.white;
			
								if (GUILayout.Button ("Join Room")) {
				
										//check2 = 1;
										PhotonNetwork.JoinRoom(game.name); // Next to each room there is a button to join the listed game.name in the current loop.
								}
						}
		
						GUILayout.EndScrollView ();
						GUILayout.EndArea ();

				}
	}
	void OnJoinedLobby()
	{
		//Debug.Log ("OnJoinedLobby");
		//PhotonNetwork.JoinRandomRoom ();
		//PhotonNetwork.JoinRandomRoom ();
	}
	void OnPhotonRandomJoinFailed()
	{
		//Debug.Log ("OnPhotonRandomJoinFailed");
		PhotonNetwork.CreateRoom (null);
		
	}
		

	void OnJoinedRoom()
	{
		
		Debug.Log ("OnJoinedRoom");
		SpawnMyPlayer ();
		//photon
		//photonView.RPC ("SpawnMyPlayer",PhotonTargets.All);
	}
	//[RPC]
	//void checkValue(spawnspot s,int v)
	//{
		///s.GetComponent<PhotonView> ().RPC ("ValueOfTheSpace", PhotonTargets.All,s,this.gameObject);
		//value = v;
		//}



	//[RPC]
	void SpawnMyPlayer()
	{
	
				if (spawnstuff == null) {
						Debug.LogError ("NO CLUE");
						return;
		}
				//spawnspot myspot = spawnstuff [Random.Range (0, spawnstuff.Length)];
		//this.GetComponent<PhotonView> ().RPC ("checkValue", PhotonTargets.All,myspot,myspot,0);
		x = PhotonNetwork.playerList.Length;
		if (x == null)
						x = 0;
		Debug.Log ("x=" + x);
		spawnspot myspot = spawnstuff [x];
				 
						GameObject myplayer = (GameObject)PhotonNetwork.Instantiate ("Viking", myspot.transform.position, myspot.transform.rotation, 0);
						//new
						myplayer.AddComponent<BoidController>();
						GameObject doggie = (GameObject)PhotonNetwork.Instantiate ("Golden_Retriever@sniff_3", myspot.transform.position + dog, myspot.transform.rotation, 0);
						
						
						//new
						//GameObject doggie = (GameObject)PhotonNetwork.Instantiate("Golden_Retriever@sniff_3",myspot.transform.position+dog,myspot.transform.rotation,0);
						doggie.AddComponent<BoidFlocking> ();
						myplayer.GetComponent<BoidController>().add_pet(doggie);



		StandByCamera.SetActive (false);
						myplayer.gameObject.SetActive (true);
						//((MonoBehaviour)myplayer.GetComponent("ThirdPersonController")).enabled=true;
		
						//		((MonoBehaviour)myplayer.GetComponent("ThirdPersonCamera")).enabled=true;
		
						((MonoBehaviour)myplayer.GetComponent ("FPSInputController")).enabled = true;
						//	((MonoBehaviour)myplayer.GetComponent("MouseLook")).enabled=true;
						((MonoBehaviour)myplayer.GetComponent ("CharacterMotor")).enabled = true;
	
						myplayer.transform.FindChild ("Main Camera").gameObject.SetActive (true);
			//myspot.GetComponent<PhotonView> ().RPC ("Occupied", PhotonTargets.All);
						//	myplayer.transform = myplayer.transform;
				


		}
	}
