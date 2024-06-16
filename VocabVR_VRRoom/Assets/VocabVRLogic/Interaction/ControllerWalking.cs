using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerWalking : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject CenterEyeCamera;
    public GameObject forwardDirection;

    private Vector3 positionPreviousFrameLeftHand;
    private Vector3 positionPreviousFrameRightHand;
    private Vector3 playerPositionPreviousFrame;
    private Vector3 playerPositionThisFrame;
    private Vector3 positionThisFrameLeftHand;
    private Vector3 positionThisFrameRightHand;

    public float speed = 70;
    private float handSpeed;

    void Start()
    {
        playerPositionPreviousFrame = transform.position;
        positionPreviousFrameLeftHand = leftHand.transform.position;
        positionPreviousFrameRightHand = rightHand.transform.position;
    }

    void Update()
    {
        float yRotation = CenterEyeCamera.transform.eulerAngles.y;
        forwardDirection.transform.eulerAngles = new Vector3(0, yRotation, 0);

        positionThisFrameLeftHand = leftHand.transform.position;
        positionThisFrameRightHand = rightHand.transform.position;
        playerPositionThisFrame = transform.position;

        var playerDistanceMoved = Vector3.Distance(playerPositionThisFrame, playerPositionPreviousFrame);
        var leftHandDistanceMoved = Vector3.Distance(positionPreviousFrameLeftHand, positionThisFrameLeftHand);
        var rightHandDistanceMoved = Vector3.Distance(positionPreviousFrameRightHand, positionThisFrameRightHand);

        handSpeed = ((leftHandDistanceMoved - playerDistanceMoved) + (rightHandDistanceMoved - playerDistanceMoved));

        if (Time.timeSinceLevelLoad > 1f)
            transform.position += forwardDirection.transform.forward * handSpeed * speed * Time.deltaTime;

        positionPreviousFrameLeftHand = positionThisFrameLeftHand;
        positionPreviousFrameRightHand = positionThisFrameRightHand;
        playerPositionPreviousFrame = playerPositionThisFrame;
    }
}
