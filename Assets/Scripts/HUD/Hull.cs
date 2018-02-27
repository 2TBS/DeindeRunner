/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Hull : MonoBehaviour {
	public Sprite emptyHealthPellet;
	public Sprite fullHealthPellet;
	GameObject health;
	GameObject healthPellet1;
	GameObject healthPellet2;
	GameObject healthPellet3;
	GameObject healthPellet4;
	GameObject healthPellet5;
	PL_Health healthController;
	// Use this for initialization
	void Start () {
		//emptyPellet = Resources.Load("EmptyHealthPellet", typeof(Sprite)) as Sprite;
		//fullPellet = Resources.Load("FullHealthPellet", typeof(Sprite)) as Sprite;
		health = GameObject.Find ("PlayerShip");
		healthPellet1 = GameObject.Find ("FullHealthPellet (1)");
		healthPellet2 = GameObject.Find ("FullHealthPellet (2)");
		healthPellet3 = GameObject.Find ("FullHealthPellet (3)");
		healthPellet4 = GameObject.Find ("FullHealthPellet (4)");
		healthPellet5 = GameObject.Find ("FullHealthPellet (5)");
		healthController = health.GetComponent <PL_Health> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (healthController.hullHealth / 2 > 4) {
			healthPellet1.GetComponent<Image> ().sprite = fullHealthPellet;
			healthPellet2.GetComponent<Image> ().sprite = fullHealthPellet;
			healthPellet3.GetComponent<Image> ().sprite = fullHealthPellet;
			healthPellet4.GetComponent<Image> ().sprite = fullHealthPellet;
			healthPellet5.GetComponent<Image> ().sprite = fullHealthPellet;
		} else if (healthController.hullHealth / 2 > 3) {
			healthPellet1.GetComponent<Image> ().sprite = fullHealthPellet;
			healthPellet2.GetComponent<Image> ().sprite = fullHealthPellet;
			healthPellet3.GetComponent<Image> ().sprite = fullHealthPellet;
			healthPellet4.GetComponent<Image> ().sprite = fullHealthPellet;
			healthPellet5.GetComponent<Image> ().sprite = emptyHealthPellet;
		} else if (healthController.hullHealth / 2 > 2) {
			healthPellet1.GetComponent<Image> ().sprite = fullHealthPellet;
			healthPellet2.GetComponent<Image> ().sprite = fullHealthPellet;
			healthPellet3.GetComponent<Image> ().sprite = fullHealthPellet;
			healthPellet4.GetComponent<Image> ().sprite = emptyHealthPellet;
			healthPellet5.GetComponent<Image> ().sprite = emptyHealthPellet;
		} else if (healthController.hullHealth / 2 > 1) {
			healthPellet1.GetComponent<Image> ().sprite = fullHealthPellet;
			healthPellet2.GetComponent<Image> ().sprite = fullHealthPellet;
			healthPellet3.GetComponent<Image> ().sprite = emptyHealthPellet;
			healthPellet4.GetComponent<Image> ().sprite = emptyHealthPellet;
			healthPellet5.GetComponent<Image> ().sprite = emptyHealthPellet;
		} else if (healthController.hullHealth / 2 > 0) {
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
*/