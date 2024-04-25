using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinText : MonoBehaviour
{
    [SerializeField] GameObject winPrefab;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject winObject = Instantiate(winPrefab, transform.position, Quaternion.identity);

            StartCoroutine(DestroyWinObject(winObject));
        }
        
    }

    IEnumerator DestroyWinObject(GameObject winObject)
    {
        yield return new WaitForSeconds(2f);

        if (winObject != null)
        {
            Destroy(winObject);
        }
    }
}
