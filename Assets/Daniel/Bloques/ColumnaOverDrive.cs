using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnaOverDrive : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("GOverdrive"))
        {
            gameObject.SetActive(false);
        }
    }
}
