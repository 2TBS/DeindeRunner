using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    float CameraSpeed = 0.02f;
	// Use this for initialization
	void Start () {
        Debug.Log("");
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right * CameraSpeed);
	}
}
