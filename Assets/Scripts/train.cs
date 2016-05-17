///<summary>
///----------------------------------------------------------------
///Author: Dylan Stephens
///Date Created: 16/5/16
///Date Modified:
///----------------------------------------------------------------
/// Brief: This code tells the trains how to behave.
/// Viewed: http://docs.unity3d.com/ScriptReference/MonoBehaviour.Invoke.html
///         http://docs.unity3d.com/ScriptReference/Handheld.Vibrate.html
/// </summary>


using UnityEngine;
using System.Collections;

public class train : MonoBehaviour {
    bool change;
    int track;
    public float speed;
    public GameObject Engine; //TODO: ?
    public GameObject main;
    // Use this for initialization
    void Start ()
    {
        main = GameObject.FindGameObjectWithTag("MainCamera");
	}

	public void create(int a_track, bool a_change)
    {
        change = a_change;
        track = a_track;
    }

	// Update is called once per frame
	void Update () {
        Debug.Log("Update one2");
        // just moves the train forward
        gameObject.transform.Translate(Vector3.back * speed * Time.deltaTime);

        //deletes trains when they have gone off screen
        if (gameObject.transform.position.z< main.transform.position.z-280)
        {

            Destroy(gameObject);
        }
    }
}
