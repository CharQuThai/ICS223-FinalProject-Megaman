using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float smoothTime = 0.3f;
    [SerializeField] Vector3 offsetPos;
    [SerializeField] Vector3 boundMin;
    [SerializeField] Vector3 boundMax;

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        if (player != null)
        {
            Vector3 targetPos = player.position + offsetPos;
            targetPos.x = Mathf.Clamp(targetPos.x, boundMin.x, boundMax.x);
            targetPos.y = Mathf.Clamp(targetPos.y, boundMin.y, boundMax.y);
            targetPos.z = transform.position.z;

            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
        }
    }
}
