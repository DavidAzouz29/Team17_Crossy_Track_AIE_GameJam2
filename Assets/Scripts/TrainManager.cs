///<summary>
///----------------------------------------------------------------
///Author: Dylan Stephens
///Date Created: 16/5/16
///Date Modified:
///----------------------------------------------------------------
///
using UnityEngine;
using System.Threading;
using System.Collections;

public class TrainManager : MonoBehaviour {
    bool t1;
    bool t2;
    bool t3;
    bool t4;
    bool t5;
    int numberOfActiveTracks = 3;
    float currentTime;
    public float timeBetweenTrains;
    public GameObject baseTrain;
    //public GameObject warningSign;
    public Sprite c_WarningSign;
    // Use this for initialization
    void Start () {
        t1 = false;
        t2 = false;
        t3 = false;

        t4 = true;
        t5 = true;
		currentTime = timeBetweenTrains - 0.1f;
        Debug.Log("Point one");
	}
	
	// Update is called once per frame
	void Update () {
        // if the level is higher than 2
        Debug.Log("Update one");


        currentTime += Time.deltaTime;
        //if the current time is higher than the time set between trains.
        if (currentTime>timeBetweenTrains)
        {
            int nextTrainsTrack = Random.Range(1, numberOfActiveTracks+1);
            currentTime = 0.0f;
            Debug.Log(nextTrainsTrack);
            StartCoroutine(warning(nextTrainsTrack));
            
        }

    }
    private IEnumerator warning(int nextTrainsTrack)
    {
        for (int i = 0; i < 3; ++i)
        {
            //instantiate warning --TODO
            //warningSign.SetActive(true);
            //c_WarningSign
            yield return new WaitForSeconds(1);
            
            
        }

        Vector3 trainPos = new Vector3(-2.9f+8.71f * nextTrainsTrack, 0, 280);
        Debug.Log(trainPos);
        Quaternion Rotation = new Quaternion(0, 0, 0, 0);
        Instantiate(baseTrain, trainPos, Rotation);
        Debug.Log("We got here");
        yield break;
    }
}
