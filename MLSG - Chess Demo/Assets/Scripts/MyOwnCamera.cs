using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyOwnCamera : MonoBehaviour {

    float timeToReachTarget;
    float currentTime;
    Vector3 startPosition;
    Vector3 endPosition;
    Quaternion startRotation;
    Quaternion endRotation;

    void Start()
    {
        startPosition = endPosition = transform.position;
        startRotation = endRotation = transform.rotation;
    }

    void Update()
    {
        currentTime += Time.deltaTime / timeToReachTarget;

        transform.position = Vector3.Lerp(startPosition, endPosition, currentTime);
        transform.rotation = Quaternion.Slerp(startRotation, endRotation, currentTime);
    }

    public void SetDestination(Vector3 destination_position, Quaternion destination_rotation, float time)
    {
        //Reset Timer for Lerp
        currentTime = 0;

        //Get the new Starting positions
        startPosition = transform.position;
        startRotation = transform.rotation;

        //set the new End positions
        endPosition = destination_position;
        endRotation = destination_rotation;

        //Set new time duration
        timeToReachTarget = time;
    }
}
