/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Ammo : MonoBehaviour {
	public Sprite fullBulletPellet;
	public Sprite emptyBulletPellet;
	public GameObject ammo;
	GameObject bulletPellet1;
	GameObject bulletPellet2;
	GameObject bulletPellet3;
	GameObject bulletPellet4;
	GameObject bulletPellet5;
	PL_Shooting shootController;
	// Use this for initialization
	void Start () {
		ammo = GameObject.Find ("PlayerShip");
		bulletPellet1 = GameObject.Find ("BulletPellet (1)");
		bulletPellet2 = GameObject.Find ("BulletPellet (2)");
		bulletPellet3 = GameObject.Find ("BulletPellet (3)");
		bulletPellet4 = GameObject.Find ("BulletPellet (4)");
		bulletPellet5 = GameObject.Find ("BulletPellet (5)");
		shootController = ammo.GetComponent <PL_Shooting> ();
    
	}
	
	// Update is called once per frame
	void Update () {
		if (shootController.ammo == 5) {
			bulletPellet1.GetComponent<Image> ().sprite = fullBulletPellet;
			bulletPellet2.GetComponent<Image> ().sprite = fullBulletPellet;
			bulletPellet3.GetComponent<Image> ().sprite = fullBulletPellet;
			bulletPellet4.GetComponent<Image> ().sprite = fullBulletPellet;
			bulletPellet5.GetComponent<Image> ().sprite = fullBulletPellet;
		} else if (shootController.ammo == 4) {
			bulletPellet1.GetComponent<Image> ().sprite = fullBulletPellet;
			bulletPellet2.GetComponent<Image> ().sprite = fullBulletPellet;
			bulletPellet3.GetComponent<Image> ().sprite = fullBulletPellet;
			bulletPellet4.GetComponent<Image> ().sprite = fullBulletPellet;
			bulletPellet5.GetComponent<Image> ().sprite = emptyBulletPellet;
		} else if (shootController.ammo == 3) {
			bulletPellet1.GetComponent<Image> ().sprite = fullBulletPellet;
			bulletPellet2.GetComponent<Image> ().sprite = fullBulletPellet;
			bulletPellet3.GetComponent<Image> ().sprite = fullBulletPellet;
			bulletPellet4.GetComponent<Image> ().sprite = emptyBulletPellet;
			bulletPellet5.GetComponent<Image> ().sprite = emptyBulletPellet;
		} else if (shootController.ammo == 2) {
			bulletPellet1.GetComponent<Image> ().sprite = fullBulletPellet;
			bulletPellet2.GetComponent<Image> ().sprite = fullBulletPellet;
			bulletPellet3.GetComponent<Image> ().sprite = emptyBulletPellet;
			bulletPellet4.GetComponent<Image> ().sprite = emptyBulletPellet;
			bulletPellet5.GetComponent<Image> ().sprite = emptyBulletPellet;
		} else if (shootController.ammo == 1) {
			bulletPellet1.GetComponent<Image> ().sprite = fullBulletPellet;
			bulletPellet2.GetComponent<Image> ().sprite = emptyBulletPellet;
			bulletPellet3.GetComponent<Image> ().sprite = emptyBulletPellet;
			bulletPellet4.GetComponent<Image> ().sprite = emptyBulletPellet;
			bulletPellet5.GetComponent<Image> ().sprite = emptyBulletPellet;
		} else {
			bulletPellet1.GetComponent<Image> ().sprite = emptyBulletPellet;
			bulletPellet2.GetComponent<Image> ().sprite = emptyBulletPellet;
			bulletPellet3.GetComponent<Image> ().sprite = emptyBulletPellet;
			bulletPellet4.GetComponent<Image> ().sprite = emptyBulletPellet;
			bulletPellet5.GetComponent<Image> ().sprite = emptyBulletPellet;
		}
	}
}*/