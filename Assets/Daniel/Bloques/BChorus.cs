using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BChorus : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Chorus") || collision.CompareTag("GChorus1") || collision.CompareTag("Chorus2") || collision.CompareTag("Chorus3") || collision.CompareTag("GChorus2"))
        {
            gameObject.SetActive(false);
        }
    }
}
