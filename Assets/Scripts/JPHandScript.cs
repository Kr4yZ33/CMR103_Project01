using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JPHandScript : MonoBehaviour
{
    public JPColourChange theCube;
    public TrackController trackController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var hand = GetComponent<OVRHand>();
        bool isIndexFingerPinching = hand.GetFingerIsPinching(OVRHand.HandFinger.Index);

        if (isIndexFingerPinching)
        {
            //is pinching., do something
            theCube.SetGreen();
            trackController.isHeld = false;

        }
        else
        {
            //not pinching
            theCube.SetRed();
        }

        float ringFingerPinchStrength = hand.GetFingerPinchStrength(OVRHand.HandFinger.Ring);
    }
}