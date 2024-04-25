using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCanvas : MonoBehaviour
{
    public float delay = 2f; // Delay in seconds before disabling the canvas
    private Canvas canvas;

    void Start()
    {
        canvas = GetComponent<Canvas>();
        // Start the coroutine to disable the canvas after the delay
        StartCoroutine(DisableCanvasDelayed());
    }

    IEnumerator DisableCanvasDelayed()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Disable the canvas
        canvas.enabled = false;
    }
}