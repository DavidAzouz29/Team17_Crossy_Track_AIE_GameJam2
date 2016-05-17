/// -------------------------------------------------
/// <summary>
/// Author: 		David Azouz and Dylan
/// Date Created: 	16/05/16
/// Date Modified: 	16/05/16
/// --------------------------------------------------
/// Brief: A Track class that handles creation of tracks
/// viewed http://docs.unity3d.com/ScriptReference/Handheld.Vibrate.html
/// 
/// 
/// ***EDIT***
/// -  	- David Azouz 16/05/16
/// 
/// </summary>
/// -------------------------------------------------
/// 
using UnityEngine;
using System.Collections;

public class TrackMachine : MonoBehaviour
{
    // PUBLIC VARIABLES
    public GameObject c_TrackStraight;
    //public GameObject c_Track;

    // PRIVATE VARIABLES
    float fTrackWidth = 8.71f;
    float fTrackLength = 27.87f;
    short sTrackNumber = 5;
    Quaternion qRotation = new Quaternion(0, 0, 0, 0);
    private Vector3 v3TrackPosWide = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        TrackCreator();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Instantiates Tracks
    void TrackCreator()
    {
        // create 'x' number of tracks based off sTrackNumber.
        // this is how wide they are.
        for (short i = 0; i < sTrackNumber; ++i)
        {

            // create 'x' number of tracks based off sTrackNumber.
            // at the end on a track.
            for (short j = 0; j < 10; ++j)
            {
                //Length
                Vector3 v3TrackPosLong = new Vector3(-20+i * fTrackWidth, -4.5f, j * fTrackLength);
                Instantiate(c_TrackStraight, v3TrackPosLong + v3TrackPosWide * j, qRotation);
            }

        }
    }
}
