using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CurrentItem : MonoBehaviour, IPointerClickHandler {

	[HideInInspector]
	public int index;

	GameObject inventoryobj;
	Inventory inventory;


	void Start () {
		inventoryobj = GameObject.FindWithTag ("InventoryManager");
		inventory = inventoryobj.GetComponent<Inventory> ();
	}
		
	public void OnPointerClick (PointerEventData eventData){
		if (eventData.button == PointerEventData.InputButton.Right) {
			if (inventory.item [index].id != 0) {
				GameObject dropdeObj = Instantiate (Resources.Load<GameObject> (inventory.item [index].pathPrefab));
				dropdeObj.transform.position = Camera.main.transform.position + Camera.main.transform.forward;
				if (inventory.item [index].countItem > 1) {
					inventory.item [index].countItem--;
				} else {
					inventory.item [index] = new Item ();
				}
				inventory.DisplayItems ();
			}
		}
	}
}
