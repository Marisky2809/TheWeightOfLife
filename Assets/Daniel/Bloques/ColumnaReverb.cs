using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnaReverb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GReverb"))
        {
            gameObject.SetActive(false);
        }
    }
}

