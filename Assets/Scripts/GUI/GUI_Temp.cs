using UnityEngine;
using System.Collections;

public class GUI_Temp : MonoBehaviour {

    public GameObject hero;
    public GameObject choosedObj;
	public GameObject leftClickedObj;
    public string lossTeam;
	private string msg;
	public Texture test;
	public Texture BasicUI;
	public float textureRatio;


	// Use this for initialization
	void Start () {
        choosedObj = hero;
		leftClickedObj = null;
        lossTeam = null;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void MessageToWorld(string m)
	{
		msg = m;
		//vanish after several seconds

	}


    void OnGUI()
    {
		float textureWidth = BasicUI.width;
		float textureHeight = BasicUI.height;
		 textureRatio = Screen.width / textureWidth;

		float textureAdjustHeight = Screen.width * textureHeight / textureWidth;
		float textureStartY = Screen.height - textureAdjustHeight;
		GUI.DrawTexture (new Rect (0, textureStartY, Screen.width, textureAdjustHeight), BasicUI);



		float bagStartX = 662 *textureRatio;
		//float bagStartY = 86*textureRatioHeight + textureStartY;
		float bagStartY =Screen.height-(327-186)*textureRatio;
		float height = (700 - 662)*textureRatio;
		float border = (714 - 699) * textureRatio;


		if (choosedObj.GetComponent<HeroInventory> ()) {
			for(int i=0;i<choosedObj.GetComponent<HeroInventory> ().getItems().Count;i++)
			{
				float x=bagStartX+i%2*(height+border);
				float y=bagStartY+i/2*(height+border);


				//float x=640+i%2*50;
				//float y=450+i/2*50;
				GUI.DrawTexture(new Rect(x,y,height,height),test);
			}
		}

		if(leftClickedObj!=null){
		if (leftClickedObj.tag == Tags.Shop) {
				if (GUI.Button(new Rect(420, 40, 80, 20), "Buy Shoes"))
				{
					choosedObj.GetComponent<AstarPlayer>().speed+=100;
				}
				if (GUI.Button(new Rect(420, 100, 80, 20), "Buy Cloth"))
				{
					
				}
				if (GUI.Button(new Rect(420, 160, 80, 20), "Buy Pokeman"))
				{
					ItemBase item=new ItemBase();
					choosedObj.GetComponent<HeroInventory>().addItem(item);
				}		
			}
		}
        if (choosedObj == hero)
        {
            if (GUI.Button(new Rect(20, 40, 80, 20), "Create Pet"))
            {
                hero.GetComponent<HeroPet>().CreatePet();
            }
        }
        else 
        {
            if (GUI.Button(new Rect(20, 40, 80, 20), "Wander"))
            {
				Debug.Log("wander");
				choosedObj.GetComponent<Wander> ().enabled = true;
				choosedObj.GetComponent<CharacterFollow> ().enabled = false;
				choosedObj.GetComponent<BoidFlocking> ().enabled = false;
            }
            if (GUI.Button(new Rect(20, 100, 80, 20), "Stay"))
            {
				choosedObj.GetComponent<Wander> ().enabled = false;
				choosedObj.GetComponent<CharacterFollow> ().enabled = false;
				choosedObj.GetComponent<BoidFlocking> ().enabled = false;
            }
            if (GUI.Button(new Rect(20, 160, 80, 20), "Follow"))
            {
				choosedObj.GetComponent<Wander> ().enabled = false;
				choosedObj.GetComponent<CharacterFollow> ().enabled = true;
				choosedObj.GetComponent<BoidFlocking> ().enabled = true;
            }
        }
        if (lossTeam!=null)
        {
            GUI.Label(new Rect(10, 10, 100, 90), lossTeam + " loss");
            Time.timeScale = 0;
        }

		GUI.Label(new Rect(400, 10, 100, 90), "money: ");
		GUI.Label(new Rect(400, 50, 100, 90), "Captured: ");
		GUI.Label(new Rect(100, 10, 100, 90), msg);
        
        
    }
}
