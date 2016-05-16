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
    public GameObject warningSign;
    // Use this for initialization
    void Start () {
        t1 = false;
        t2 = false;
        t3 = false;

        t4 = true;
        t5 = true;
        currentTime = 0;
	}
	
	// Update is called once per frame
	/*void Update () {
        // if the level is higher than 2
	    if (gameObject.GetComponent<levelManager>().currentLevel>2)
        {
            numberOfActiveTracks = 4;
        }
        // if the level is higher than 5
        if (gameObject.GetComponent<levelManager>().currentLevel > 5)
        {
            numberOfActiveTracks = 5;
        }

        currentTime += Time.deltaTime;
        //if the current time is higher than the time set between trains.
        if (currentTime>timeBetweenTrains)
        {
            int nextTrainsTrack = Random.Range(1, numberOfActiveTracks+1);
            currentTime = 0.0f;

            StartCoroutine(warning(nextTrainsTrack));





            

        }

    } */
    private IEnumerator warning(int nextTrainsTrack)
    {
        for (int i = 0; i < 3; ++i)
        {
            //instantiate warning --TODO
            yield return new WaitForSeconds(1);
            
            
        }


        Vector3 trainPos = new Vector3(25 * nextTrainsTrack, 0, 0);
        Debug.Log(trainPos);
        Quaternion Rotation = new Quaternion(0, 0, 0, 0);
        Instantiate(baseTrain, trainPos, Rotation);
        
        yield break;
    }
}
