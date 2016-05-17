/// <summary>
/// viewed: http://forum.unity3d.com/threads/swipe-help-please.48601/
/// http://answers.unity3d.com/questions/35803/touch-screen-horizontal-or-vertical-swipe.html
/// http://docs.unity3d.com/ScriptReference/MonoBehaviour.StartCoroutine.html
/// http://itween.pixelplacement.com/documentation.php
/// </summary>

using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    // PUBLIC VARIABLES
    [Header("Health Settings")]
    [Tooltip("Movement Interval.")]
    public float fMovement = 8.4f;
    [Header("Time for Lerping")]
    public float fRot = 0f;
    public Animator c_CharacterMovement;

    public GameObject c_Position1;
    public GameObject c_Position2;
    public GameObject c_Position3;

    float[] c_positions;
    public int fCurrentLocation = 1; // Zero based from our three locations

    // PRIVATE VARIABLES
    private float swipeStartTime;
    private Vector2 startPos;
    private bool couldBeSwipe;
    private float minSwipeDist = 10;
    private float maxSwipeTime = 0.3f;
    

    // -----------------------------------
    // Touch Swipe Controls
    // -----------------------------------
    bool hasTouch;
    bool touchBegan;
    Vector2 touchPos;

    float swipeTime;
    float swipeDist;

    Vector3 v3FuturePos;

    bool isRight;
    bool isLeft;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(CheckHorizontalSwipes());
        c_positions[0] = c_Position1.transform.position.x;
        c_positions[1] = c_Position2.transform.position.x;
        c_positions[2] = c_Position3.transform.position.x;
    }

    IEnumerator CheckHorizontalSwipes() //Coroutine, which gets Started in "Start()" and runs over the whole game to check for swipes
    {
        //Loop. Otherwise we wouldnt check continoulsy
        while (true)
        {
            hasTouch = false;
            touchBegan = false;
            touchPos = Vector2.zero;

            //If not PC/ Mac/ Linux i.e. Android
#if !UNITY_STANDALONE || !UNITY_EDITOR
            //For every touch in the Input.touches - array...
            foreach (Touch touch in Input.touches)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        hasTouch = true;
                        touchBegan = true;
                        touchPos = touch.position;
                        break;

                    case TouchPhase.Stationary: //couldBeSwipe = false;
                    case TouchPhase.Moved:
                        hasTouch = true;
                        touchBegan = false;
                        touchPos = touch.position;
                        break;

                    default:
                        hasTouch = false;
                        touchPos = Vector2.zero;
                        break;
                }
            }
#elif UNITY_STANDALONE || UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))
            {
                hasTouch = true;
                touchBegan = true;
                touchPos = Input.mousePosition;
            }
            else if (Input.GetMouseButton(0))
            {
                hasTouch = true;
                touchPos = Input.mousePosition;
            }
#endif
            if (hasTouch && touchBegan)
            {
                //The finger first touched the screen --> It could be(come) a swipe
                couldBeSwipe = true;
                startPos = touchPos;  //Position where the touch started
                swipeStartTime = Time.time; //The time it started
            }

            swipeTime = Time.time - swipeStartTime; //Time the touch stayed at the screen till now.
            swipeDist = Mathf.Abs(touchPos.x - startPos.x); //Swipe distance

            // Debug.LogFormat("Swipe: Time: {0} Dist: {1} Start: {2}", swipeTime, swipeDist, swipeStartTime);

            fRot += Time.deltaTime;

            // if we swipe...
            if (couldBeSwipe && swipeTime < maxSwipeTime && swipeDist > minSwipeDist) // && fRot <= 0.3f
            {
                //<-- Otherwise this part would be called over and over again.
                couldBeSwipe = false;

                //Swipe-direction, either 1 or -1.
                if (Mathf.Sign(touchPos.x - startPos.x) == 1f)
                {
                    //----------Right-swipe----------
                    isRight = true;
                    Invoke("MoveRight", 1);
                    //v3FuturePos.x = gameObject.transform.localPosition.x + fMovement;
                    v3FuturePos.x = c_positions[++fCurrentLocation];
                    c_CharacterMovement.CrossFade("LeanRight", 0.3f);
                    Debug.Log("Right");
                }
                else
                {
                    //----------Left-swipe----------
                    isLeft = true;
                    Invoke("MoveLeft", 1);
                    //v3FuturePos.x = gameObject.transform.localPosition.x - fMovement;
                    v3FuturePos.x = c_positions[--fCurrentLocation];
                    //v3FuturePos.x = c_Position1.transform.position.x;
                    c_CharacterMovement.CrossFade("LeanLeft", 0.3f);
                    Debug.Log("Left");
                }
                fRot = 0;
            }

            if(isRight || isLeft)
            {
                gameObject.transform.localPosition = Vector3.Lerp(gameObject.transform.localPosition, v3FuturePos, fRot);
            }

            yield return null;
        }
    }

    void MoveRight()
    {
        isRight = false;
    }

    void MoveLeft()
    {
        isLeft = false;
    }
}
