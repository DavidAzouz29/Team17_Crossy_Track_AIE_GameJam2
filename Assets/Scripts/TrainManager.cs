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
    public Sprite c_WarningSign;
	public GameObject c_Score;
    // Use this for initialization
    void Start () {
        t1 = false;
        t2 = false;
        t3 = false;

        t4 = true;
        t5 = true;

	}
	
	// Update is called once per frame
	void Update () {
		// Makes the trains get slowly faster.
		if (timeBetweenTrains > 0.4f) {
			timeBetweenTrains = 1.0f - c_Score.GetComponent<Score> ().fTimePassed / 75;
		}
        currentTime += Time.deltaTime;
        //if the current time is higher than the time set between trains.
        if (currentTime>timeBetweenTrains)
        {
            int nextTrainsTrack = Random.Range(1, numberOfActiveTracks+1);
            currentTime = 0.0f;
            StartCoroutine(warning(nextTrainsTrack));
            
        }

    }
    private IEnumerator warning(int nextTrainsTrack)
    {
        for (int i = 0; i < 3; ++i)
        {
            //instantiate warning --TODO
            warningSign.SetActive(true);
            //c_WarningSign
            yield return new WaitForSeconds(0);
            
            
        }

        Vector3 trainPos = new Vector3(-16.5f+8.71f * nextTrainsTrack, 0, 280);
        Quaternion Rotation = new Quaternion(0, 0, 0, 0);
        Instantiate(baseTrain, trainPos, Rotation);
        yield break;
    }
}
