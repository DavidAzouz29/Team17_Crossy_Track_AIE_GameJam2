/// <summary>
/// viewed: http://forum.unity3d.com/threads/swipe-help-please.48601/
/// http://answers.unity3d.com/questions/35803/touch-screen-horizontal-or-vertical-swipe.html
/// </summary>

using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    // PUBLIC VARIABLES
    public int iMovement = 1;
    //public Animation c_CharacterMovementAnimation;

    // PRIVATE VARIABLES
    private float swipeStartTime;
    private Vector2 startPos;
    private bool couldBeSwipe;
    private float minSwipeDist = 10;
    private float maxSwipeTime = 0.3f;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(CheckHorizontalSwipes());
    }

    // Update is called once per frame
    void Update()
    {
        // #elif UNITY_STANDALONE || UNITY_EDITOR
        //UNITY_ANDROID
    }

    //#if !UNITY_STANDALONE || !UNITY_EDITOR
    IEnumerator CheckHorizontalSwipes() //Coroutine, which gets Started in "Start()" and runs over the whole game to check for swipes
    {
        //Loop. Otherwise we wouldnt check continoulsy ;-)
        while (true)
        {
            bool hasTouch = false;
            bool touchBegan = false;
            Vector2 touchPos = Vector2.zero;

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

                    case TouchPhase.Stationary:
                    case TouchPhase.Moved:
                        hasTouch = true;
                        touchBegan = false;
                        touchPos = touch.position;
                        break;

                    default:
                        touchPos = Vector2.zero;
                        hasTouch = false;
                        break;
                }
            }

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

            if (hasTouch && touchBegan)
            {
                //The finger first touched the screen --> It could be(come) a swipe
                couldBeSwipe = true;
                startPos = touchPos;  //Position where the touch started
                swipeStartTime = Time.time; //The time it started
            }
            //Is the touch stationary? --> No swipe then!
            /*case TouchPhase.Stationary:
                couldBeSwipe = false;
                break; 

            default:
                {
                    Debug.Log("Movement Error");
                    break;
                } */

            float swipeTime = Time.time - swipeStartTime; //Time the touch stayed at the screen till now.
            float swipeDist = Mathf.Abs(touchPos.x - startPos.x); //Swipe distance

           // Debug.LogFormat("Swipe: Time: {0} Dist: {1} Start: {2}", swipeTime, swipeDist, swipeStartTime);

            // if we swipe...
            if (couldBeSwipe && swipeTime < maxSwipeTime && swipeDist > minSwipeDist)
            {
                //<-- Otherwise this part would be called over and over again.
                couldBeSwipe = false;

                //Swipe-direction, either 1 or -1.
                if (Mathf.Sign(touchPos.x - startPos.x) == 1f)
                {
                    //Right-swipe
                    gameObject.transform.Translate(iMovement, 0, 0);
                    gameObject.transform.Rotate(Mathf.Lerp(0, 1, Time.deltaTime), 0, 0);
                    //c_CharacterMovementAnimation.Play();
                    Debug.Log("Right");
                }
                else
                {
                    //Left-swipe
                    gameObject.transform.Translate(-iMovement, 0, 0);
                    gameObject.transform.Rotate(Mathf.Lerp(0, -1, Time.deltaTime), 0, 0);
                    //c_CharacterMovementAnimation.Play();
                    Debug.Log("Left");
                }
            }

            yield return null;
        }
    }
//#endif
}
