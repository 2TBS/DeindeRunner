using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class HUDHealth : MonoBehaviour {
	public Sprite emptyHealthPellet;
	public Sprite fullHealthPellet;
	GameObject health;
	GameObject healthPellet1;
	GameObject healthPellet2;
	GameObject healthPellet3;
	GameObject healthPellet4;
	GameObject healthPellet5;
	private Player p1, p2;
	
	// Use this for initialization
	void Start () {
		//emptyPellet = Resources.Load("EmptyHealthPellet", typeof(Sprite)) as Sprite;
		//fullPellet = Resources.Load("FullHealthPellet", typeof(Sprite)) as Sprite;
		healthPellet1 = GameObject.Find ("FullHealthPellet (1)");
		healthPellet2 = GameObject.Find ("FullHealthPellet (2)");
		healthPellet3 = GameObject.Find ("FullHealthPellet (3)");
		healthPellet4 = GameObject.Find ("FullHealthPellet (4)");
		healthPellet5 = GameObject.Find ("FullHealthPellet (5)");
		p1 = GameObject.Find("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		if (p1.health > 4) {
			healthPellet1.GetComponent<Image> ().sprite = fullHealthPellet;
			healthPellet2.GetComponent<Image> ().sprite = fullHealthPellet;
			healthPellet3.GetComponent<Image> ().sprite = fullHealthPellet;
			healthPellet4.GetComponent<Image> ().sprite = fullHealthPellet;
			healthPellet5.GetComponent<Image> ().sprite = fullHealthPellet;
		} else if (p1.health > 3) {
			healthPellet1.GetComponent<Image> ().sprite = fullHealthPellet;
			healthPellet2.GetComponent<Image> ().sprite = fullHealthPellet;
			healthPellet3.GetComponent<Image> ().sprite = fullHealthPellet;
			healthPellet4.GetComponent<Image> ().sprite = fullHealthPellet;
			healthPellet5.GetComponent<Image> ().sprite = emptyHealthPellet;
		} else if (p1.health > 2) {
			healthPellet1.GetComponent<Image> ().sprite = fullHealthPellet;
			healthPellet2.GetComponent<Image> ().sprite = fullHealthPellet;
			healthPellet3.GetComponent<Image> ().sprite = fullHealthPellet;
			healthPellet4.GetComponent<Image> ().sprite = emptyHealthPellet;
			healthPellet5.GetComponent<Image> ().sprite = emptyHealthPellet;
		} else if (p1.health > 1) {
			healthPellet1.GetComponent<Image> ().sprite = fullHealthPellet;
			healthPellet2.GetComponent<Image> ().sprite = fullHealthPellet;
			healthPellet3.GetComponent<Image> ().sprite = emptyHealthPellet;
			healthPellet4.GetComponent<Image> ().sprite = emptyHealthPellet;
			healthPellet5.GetComponent<Image> ().sprite = emptyHealthPellet;
		} else if (p1.health > 0) {
			healthPellet1.GetComponent<Image> ().sprite = fullHealthPellet;
			healthPellet2.GetComponent<Image> ().sprite = emptyHealthPellet;
			healthPellet3.GetComponent<Image> ().sprite = emptyHealthPellet;
			healthPellet4.GetComponent<Image> ().sprite = emptyHealthPellet;
			healthPellet5.GetComponent<Image> ().sprite = emptyHealthPellet;
		} else {
			healthPellet1.GetComponent<Image> ().sprite = emptyHealthPellet;
			healthPellet2.GetComponent<Image> ().sprite = emptyHealthPellet;
			healthPellet3.GetComponent<Image> ().sprite = emptyHealthPellet;
			healthPellet4.GetComponent<Image> ().sprite = emptyHealthPellet;
			healthPellet5.GetComponent<Image> ().sprite = emptyHealthPellet;
		}
	}
}