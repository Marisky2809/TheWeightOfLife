using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalacoMira : MonoBehaviour
{
    public bool orden;
    void Start()
    {
        orden = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            orden = true;
            Debug.Log("Te agarraron");
        }
    }
}
