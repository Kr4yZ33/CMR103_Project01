using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackController : MonoBehaviour
{
    public bool isHeld; // turned on or off bythe pinch gesture in hand Scripts or OVR input controls.

    public bool transformLAttached; // is that transform already attached to something
    public bool transformRAttached; // is that transform already attached to something
    public bool transformTAttached; // is that transform already attached to something
    public bool transformBAttached; // is that transform already attached to something

    public Transform grabTransform; // attach point for the hand
    public Transform parentTransform; // track main mesh parent transform
    Transform previousTransform; // call this if tracking is lost to place the object again

    readonly Rigidbody r; // rigid body of the object this script is attached to

    void Start()
    {
        if(isHeld == true) // if the bool for being held is true
        {
            r.isKinematic = true; // turn off gravity on the rigid body
        }
        else if (isHeld != true) // if is held is not true
        {
            r.isKinematic = false; // turn gravity back on
        }
    }

    void Update()
    {
        PreviousTransformPosition(); // reference to our previous transform poistion for Object State Tracking
    }

    /// <summary>
    /// function to call and set our previous transform position varible
    /// </summary>
    void PreviousTransformPosition()
    {
        if (previousTransform == null)
        {
            previousTransform = parentTransform;
        }

        previousTransform = parentTransform;
    }
}
