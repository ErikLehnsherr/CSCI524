using UnityEngine;
using System.Collections;

public class ViewShop : MonoBehaviour {
	public Texture test;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI()
	{
		if(Camera.main!=null)
		{
			float textureRatio = Camera.main.GetComponent<GUI_Temp>().textureRatio;

			
			float bagStartX = 785 *textureRatio;
			//float bagStartY = 86*textureRatioHeight + textureStartY;
			float bagStartY =Screen.height-(327-155)*textureRatio;
			float height = (840 - 785)*textureRatio;
			float border = (714 - 699) * textureRatio;
			if(Camera.main.GetComponent<GUI_Temp>().leftClickedObj!=null)
			{
				if(Camera.main.GetComponent<GUI_Temp>().leftClickedObj.tag==Tags.Shop){
					if (GUI.Button (new Rect (bagStartX, bagStartY, height, height), test)) {
						ItemBase item=new ItemBase();
						Camera.main.GetComponent<GUI_Temp>().hero.GetComponent<HeroInventory>().addItem(item);
					}
				}
			}
		}
	}
}
