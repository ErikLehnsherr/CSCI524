using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeroInventory : MonoBehaviour {
	List<ItemBase> items;
	// Use this for initialization
	void Start () {
		items = new List<ItemBase> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void addItem(ItemBase item)
	{
		if (items.Count > 6) {
						Debug.Log ("full bag");
				}
		items.Add (item);
	}
	public List<ItemBase> getItems()
	{
		return items;
	}
}
