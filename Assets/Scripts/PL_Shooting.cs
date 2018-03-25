using System.Collections;
using System.Collections.Generic;
using UnityEngine;	

public class PL_Shooting : MonoBehaviour {

	public int ammo = 5;
	public const int DELAY = 1;
	public GameObject bulletPrefab;
	public Transform bulletSpawn;

    public AudioClip reloadClip;
    public AudioClip fireClip;

    int angle;
	Vector3 pos;
	double fireTimer = 0.0;


    // Use this for initialization
    void Start () {
		pos = new Vector3(0f, 2.1f, 0f);
	}

	// Update is called once per frame
	void Update () {
		fireTimer += Time.deltaTime;
		if (Input.GetButtonDown ("Fire1")) {
			Fire ();
		}

	}

	public void Fire() {
		if(ammo == 0)
		{
			Reload();
		}
		if (fireTimer > DELAY) {
			FireBullet ();
			AudioSource audio = GetComponent<AudioSource>();
			audio.clip = fireClip;
			audio.Play();
			fireTimer = 0.0;
		} 
		else if (fireTimer > DELAY) {
			Debug.Log ("Weapon Cooldown (Time Remaining): " + (DELAY - fireTimer).ToString());
		}
	}
    //Fire function by instantiating a bullet prefab and adding a force to push it straight up.
	void FireBullet() {
		var bullet = (GameObject)Instantiate(
			bulletPrefab,
			transform.position + pos,
			transform.rotation);
		bullet.AddComponent<Bullet> ();
		bullet.GetComponent<Bullet> ().originObject = gameObject;
		bullet.GetComponent<Rigidbody2D>().AddForce(transform.rotation * Vector2.up * 1000);
		Destroy(bullet, 2.0f);     
		ammo--;
	}

    //Reload function by playing sound and setting ammo to full
    void Reload()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = reloadClip;
        audio.Play();
        Debug.Log("reload");
        ammo = 5; //set ammo to full
    }
}