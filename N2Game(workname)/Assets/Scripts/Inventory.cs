using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	List<Item> item;
	public GameObject cellContainer;
	public KeyCode ShowInventory;
	public KeyCode takeButton;

	void Start () {
		item = new List<Item>();
		for (int i = 0; i < cellContainer.transform.childCount; i++) {
			item.Add (new Item ());
			cellContainer.SetActive (false);
		}
	}

	void Update () {
		ToggleInventory ();
		if (Input.GetKeyDown(takeButton)){
			Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width/2,Screen.height/2));
			RaycastHit hit;
			if(Physics.Raycast(ray,out hit,2f)){
				if (hit.collider.GetComponent<Item>()){
					for(int i = 0;i < item.Count;i++){
						if(item[i].id==0){
							item[i] = hit.collider.GetComponent<Item>();
							DisplayItems ();
							Destroy(hit.collider.GetComponent<Item>().gameObject);
							break;
						}
					}
				}
			}
		}
	}

	void ToggleInventory (){
		if (Input.GetKeyDown (ShowInventory)) {
			if (cellContainer.activeSelf) {
				cellContainer.SetActive (false);
			} else {
				cellContainer.SetActive (true);
			}
		}
	}

	void DisplayItems(){
		for (int i = 0; i < item.Count; i++) {
			Transform cell = cellContainer.transform.GetChild (i);
			Transform icon = cell.GetChild (0);
			Image img = icon.GetComponent<Image> ();
			if (item [i].id != 0) {
				img.enabled = true;
				img.sprite = Resources.Load<Sprite> (item [i].pathIcon);
			} else {
				img.enabled = false;
				img.sprite = null;
			}
		}
	}
}