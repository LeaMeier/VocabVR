using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerWalking : MonoBehaviour
{
    // Public fields to reference the necessary GameObjects in the Unity Inspector
    public GameObject leftHand;         
    public GameObject rightHand;        
    public GameObject CenterEyeCamera;  
    public GameObject forwardDirection; 

    // Private variables to store positions for calculating movement
    private Vector3 positionPreviousFrameLeftHand;  
    private Vector3 positionPreviousFrameRightHand; 
    private Vector3 playerPositionPreviousFrame;   
    private Vector3 playerPositionThisFrame;       
    private Vector3 positionThisFrameLeftHand;     
    private Vector3 positionThisFrameRightHand;     

    public float speed = 400f; // Speed factor for movement; adjust for smoother or faster movement
    private float handSpeed;  // Calculated speed of the hands
    public float movementThreshold = 0.01f; // Threshold to determine significant hand movement

    // Initialization method called when the script instance is being loaded
    void Start()
    {
        // Store the initial positions of the player and hands
        playerPositionPreviousFrame = transform.position;
        positionPreviousFrameLeftHand = leftHand.transform.position;
        positionPreviousFrameRightHand = rightHand.transform.position;
    }

    // Update method called once per frame
    void Update()
    {
        // Update the forward direction of the player based on the Center Eye Camera's y-axis rotation
        float yRotation = CenterEyeCamera.transform.eulerAngles.y;
        forwardDirection.transform.eulerAngles = new Vector3(0, yRotation, 0);

        // Capture the current positions of the player and hands
        positionThisFrameLeftHand = leftHand.transform.position;
        positionThisFrameRightHand = rightHand.transform.position;
        playerPositionThisFrame = transform.position;

        // Calculate the distances moved by the player and each hand since the last frame
        var playerDistanceMoved = Vector3.Distance(playerPositionThisFrame, playerPositionPreviousFrame);
        var leftHandDistanceMoved = Vector3.Distance(positionPreviousFrameLeftHand, positionThisFrameLeftHand);
        var rightHandDistanceMoved = Vector3.Distance(positionPreviousFrameRightHand, positionThisFrameRightHand);

        // Calculate hand speed based on the difference in distances moved
        handSpeed = ((leftHandDistanceMoved - playerDistanceMoved) + (rightHandDistanceMoved - playerDistanceMoved)) / 2;

        // Check if the calculated hand speed exceeds the movement threshold and ensure some time has passed
        if (handSpeed > movementThreshold && Time.timeSinceLevelLoad > 1f)
        {
            // Determine the movement direction and update player position with smoothing
            Vector3 direction = forwardDirection.transform.forward * handSpeed * speed * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, transform.position + direction, 0.5f); // Smoothly move the player
        }

        // Update previous frame positions for the next frame's calculations
        positionPreviousFrameLeftHand = positionThisFrameLeftHand;
        positionPreviousFrameRightHand = positionThisFrameRightHand;
        playerPositionPreviousFrame = playerPositionThisFrame;
    }
}
