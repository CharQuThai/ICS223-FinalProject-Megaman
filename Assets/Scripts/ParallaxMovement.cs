using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMovement : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private float matchCamXMovement = 1f;
    [SerializeField] private float matchCamYMovement = 1f;
    [SerializeField] private Vector2 offset = Vector2.zero;

    private void LateUpdate()
    {
        transform.position = new Vector2 (cam.position.x * matchCamXMovement, cam.position.y * matchCamYMovement) + offset;
    }
}
