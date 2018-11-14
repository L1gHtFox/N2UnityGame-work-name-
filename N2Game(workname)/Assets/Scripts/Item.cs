using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour {

	public string nameItem;
	public int id;
	public int countItem;
	public bool isStackable;
	[Multiline(5)]
	public string descriptionItem;
	public bool isRemoveable;
	public bool isDroped;
	public Sprite Icon;
	public UnityEvent customEvent;
}