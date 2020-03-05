using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    [SerializeField]
    float smoothing = 0.1f;

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.position != target.position) // If the transform of the camera is not the same as the target's position
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z); // Get the target's position but maintain camera's Z position
            Vector3 smothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothing); // lerp the position so it follows the player but slightly delayed
            transform.position = smothedPosition;
        }
    }
}
