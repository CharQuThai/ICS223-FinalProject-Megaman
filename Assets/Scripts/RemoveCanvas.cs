using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCanvas : MonoBehaviour
{
    public float delay = 2f; 
    private Canvas canvas;

    void Start()
    {
        canvas = GetComponent<Canvas>();

        StartCoroutine(DisableCanvasDelayed());
    }

    IEnumerator DisableCanvasDelayed()
    {

        yield return new WaitForSeconds(delay);

        canvas.enabled = false;
    }
}