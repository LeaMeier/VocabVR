using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerWalking : MonoBehaviour
{
    public Transform leftController;
    public Transform rightController;
    public Transform playerTransform;
    public float movementSpeed = 1.0f;

    private Vector3 leftControllerPreviousPosition;
    private Vector3 rightControllerPreviousPosition;

    // Start is called before the first frame update
    void Start()
    {
        leftControllerPreviousPosition = leftController.localPosition;
        rightControllerPreviousPosition = rightController.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 leftControllerDelta = leftController.localPosition - leftControllerPreviousPosition;
        Vector3 rightControllerDelta = rightController.localPosition - rightControllerPreviousPosition;

        Vector3 averageDelta = (leftControllerDelta + rightControllerDelta) / 2.0f;

        playerTransform.position += playerTransform.forward * averageDelta.z * movementSpeed;

        leftControllerPreviousPosition = leftController.localPosition;
        rightControllerPreviousPosition = rightController.localPosition;
    }
}
