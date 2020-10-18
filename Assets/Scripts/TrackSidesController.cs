using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSidesController : MonoBehaviour
{
    public TrackController trackController; // reference to our Track Controller script
    Renderer r; // reference to the renderer attached to the object this script is attached to
    public bool openForTrack; // bool for if the side can take track or not
    public bool isConnected; // bool for if the side is connected to another side or not
    public Transform trackSideTransform; // transform location for that side


    // Start is called before the first frame update
    void Start()
    {
        if(trackController.isHeld == true) // if the isHeld bool is True on the Track Controller script
        {
            isConnected = false; // set the bool for isConnected to false
        }
        
        r = GetComponent<Renderer>(); // get the rigid body of the object this script is attached to

        if(gameObject.CompareTag("NoTrackConnection")) // if the object this script is attached to has the tag NoTrackConnections
        {
            openForTrack = false; // set the bool for openForTrack to false
        }

        if (!gameObject.CompareTag("NoTrackConnection")) // if the object this script is attached to does not have the tag NoTrackConnections
        {
            openForTrack = true; // set the bool for openForTrack to true
        }

        if (gameObject.CompareTag("TrackLTransform") && isConnected == true) // if the object this script is attached to has the tag TrackLTrnsform
        {
            trackController.transformLAttached = true; // set the bool for transformLAttached to true in the Track Controller script
        }
        if (gameObject.CompareTag("TrackLTransform") && isConnected != true)
        {
            trackController.transformLAttached = false;
        }

        if (gameObject.CompareTag("TrackRTransform") && isConnected == true)
        {
            trackController.transformRAttached = true;
        }
        if (gameObject.CompareTag("TrackRTransform") && isConnected != true)
        {
            trackController.transformRAttached = false;
        }

        if (gameObject.CompareTag("TrackTTransform") && isConnected == true)
        {
            trackController.transformTAttached = true;
        }
        if (gameObject.CompareTag("TrackTTransform") && isConnected != true)
        {
            trackController.transformTAttached = false;
        }

        if (gameObject.CompareTag("TrackBTransform") && isConnected == true)
        {
            trackController.transformBAttached = true;
        }
        if (gameObject.CompareTag("TrackBTransform") && isConnected != true)
        {
            trackController.transformBAttached = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isConnected == true) // if the bool for isConnected is true
        {
            r.material.color = Color.yellow; // set our object's colour to yellow
        }

        if (openForTrack == true) // if the bool for openForTrack is true
        {
            r.material.color = Color.green; // set our object's colour to blue
        }

        if (openForTrack == false) // if the bool for openForTrack is false
        {
            r.material.color = Color.red; // set our object's colour to red
        }
    }

    /// <summary>
    /// Function to handle different collisions with the side
    /// this script is attached to
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) // if the object colliding with us has the tag player
        {
            trackController.isHeld = true; // change the bool for isHeld on the Track Controller Script to true
            isConnected = false; // set the bool for isConnected to false
            trackController.grabTransform.position = other.transform.position; //on the Track Controller script, set the grab transform position to the transform position of the hand
            trackController.grabTransform.rotation = other.transform.rotation; //on the Track Controller script, set the grab transform rotation to the transform rotation of the hand

        }

        if(!other.gameObject.CompareTag("TrackTransformClosed") && !other.gameObject.CompareTag("Player")) // if the object colliding with us does not have the tag TrackTransformClosed & does not have the tag Player
        {
            isConnected = true; // Set the bool for isConnected to true
        }
    }

    /// <summary>
    /// Function handling what to do with colliders exiting ours
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // if the collider leaving our has the tag player
        {
            trackController.isHeld = false; // set the isHeld bool to false in the Track COntroller script
        }
    }
}
