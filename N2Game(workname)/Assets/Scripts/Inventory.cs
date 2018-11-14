using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	[HideInInspector]
	public List<Item> item;

	public KeyCode ShowInventory;
	public KeyCode takeButton;

	public GameObject massageManager;
	public GameObject massage;
	public GameObject cellContainer;
	public GameObject database;

	public FPSInput fpsi;
	public MouseLook playerLook;
	public MouseLook camLook;
	public RayShooter rayShooter;

	void Start () {
		item = new List<Item>();

		for(int i = 0;i < cellContainer.transform.childCount;i++){
			cellContainer.transform.GetChild(i).GetComponent<CurrentItem>().index = i;
		}
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
					Item currentItem = hit.collider.GetComponent<Item> ();
					Massage (currentItem);
					AddItem(hit.collider.GetComponent<Item>());
					}
				}
			}
		}

	void Massage(Item currentItem){
		GameObject msgObj = Instantiate (massage);
		msgObj.transform.SetParent (massageManager.transform);

		Image msgImg = msgObj.transform.GetChild (0).GetComponent<Image> ();
		msgImg.sprite = currentItem.Icon;

		Text msgTxt = msgObj.transform.GetChild (1).GetComponent<Text>();
		msgTxt.text = currentItem.nameItem;
	}

	void AddItem(Item currentItem){
		if(currentItem.isStackable==true){
			AddStackableItem (currentItem);
		}else{
			AddUnstackableItem(currentItem);
		}
	}


	void AddUnstackableItem(Item currentItem){
		for(int i = 0;i < item.Count;i++){
			if(item[i].id==0){
				item [i] = currentItem;
				item [i].countItem = 1;
				DisplayItems ();
				Destroy(currentItem.gameObject);
				break;
			}
		}
	}

	void AddStackableItem(Item currentItem){
		for (int i = 0; i < item.Count; i++){
			if(item[i].id == currentItem.id){
				item [i].countItem++;
				DisplayItems ();
				Destroy (currentItem.gameObject);
				return;
			}
		}
		AddUnstackableItem (currentItem);
	}

	void ToggleInventory (){
		if (Input.GetKeyDown (ShowInventory)) {
			if (cellContainer.activeSelf) {
				cellContainer.SetActive (false);
				fpsi.enabled = true;
				camLook.enabled = true;
				playerLook.enabled = true;
				rayShooter.enabled = true;
				Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Locked;
				Time.timeScale = 1;
			} else {
				fpsi.enabled = false;
				camLook.enabled = false;
				playerLook.enabled = false;
				rayShooter.enabled = false;
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
				cellContainer.SetActive (true);
			}
		}
	}

	public void DisplayItems(){
		for (int i = 0; i < item.Count; i++) {
			Transform cell = cellContainer.transform.GetChild (i);
			Transform icon = cell.GetChild (0);
			Transform count = icon.GetChild (0);

			Text txt = count.GetComponent<Text> ();
			Image img = icon.GetComponent<Image> ();

			if (item [i].id != 0) {
				img.enabled = true;
				img.sprite = item [i].Icon;

				if (item [i].countItem > 1) {
					txt.text = item [i].countItem.ToString ();
				} else {
					txt.text = null;
				}
			} else {
				img.enabled = false;
				img.sprite = null;
				txt.text = null;
			}
		}
	}
}