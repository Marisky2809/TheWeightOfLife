using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] GameManager gameManager;
    [SerializeField] Image fadePanel; // Referencia al panel negro de tipo Image

    private void Start()
    {
        // Asegúrate de que el panel esté completamente transparente al inicio
        Color color = fadePanel.color;
        color.a = 0f;
        fadePanel.color = color;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.Checkpoint = gameObject.transform.position;
            sprite.color = Color.white;
        }
    }

    
}