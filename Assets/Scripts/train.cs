﻿///<summary>
///----------------------------------------------------------------
///Author: Dylan Stephens
///Date Created: 16/5/16
///Date Modified:
///----------------------------------------------------------------
/// Brief: This code tells the trains how to behave. They are spawned by the train manager
/// Viewed: http://docs.unity3d.com/ScriptReference/MonoBehaviour.Invoke.html
///         http://docs.unity3d.com/ScriptReference/Handheld.Vibrate.html
/// </summary>


using UnityEngine;
using System.Collections;

public class train : MonoBehaviour {
    public bool change;
    public float speed;
    public GameObject main;
    // Use this for initialization
    void Start ()
    {
		change = false;

		Random.seed += (int)Time.deltaTime;
		int toChange = Random.Range (0, 100);
		if (toChange < 30) {
			change = true;
		}
        main = GameObject.FindGameObjectWithTag("MainCamera");
	}
		

	// Update is called once per frame
	void Update () {
        // just moves the train forward
        gameObject.transform.Translate(Vector3.back * speed * Time.deltaTime);

        //deletes trains when they have gone off screen
        if (gameObject.transform.position.z< main.transform.position.z-280)
        {

            Destroy(gameObject);
        }
    }
}
