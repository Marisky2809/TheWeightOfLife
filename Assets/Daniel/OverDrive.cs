using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverDrive : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Collider2D collider2D;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Suelo"))
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = false;
            }

            if (collider2D != null)
            {
                collider2D.enabled = false;
            }
        }
    }
}
