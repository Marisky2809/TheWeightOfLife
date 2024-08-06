using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidasEnemigo : MonoBehaviour
{
    [SerializeField] private int vidas;
    [SerializeField] private GameObject corazon;
    [SerializeField] private GameObject Calaco;
    [SerializeField] private GameObject Golpeador;
    private SpriteRenderer spriteRenderer;
    float duration = 0.6f;
    private bool muerto = false;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(Golpeador != null)
        {
            spriteRenderer = Golpeador.GetComponent<SpriteRenderer>();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Chorus"))
        {
            vidas = vidas - 20;
            Debug.Log(vidas);
            StartCoroutine(retroalimentar());
        }
        else if(collision.CompareTag("Chorus2"))
        {
            vidas = vidas - 10;
            Debug.Log(vidas);
            StartCoroutine(retroalimentar());
        }
        else if (collision.CompareTag("Chorus3"))
        {
            vidas = vidas - 5;
            Debug.Log(vidas);
            StartCoroutine(retroalimentar());
        }
        else if (collision.CompareTag("Reverb"))
        {
            vidas = vidas - 40;
            Debug.Log(vidas);
            StartCoroutine(retroalimentar());
        }
        else if (collision.CompareTag("Reverb2"))
        {
            vidas = vidas - 20;
            Debug.Log(vidas);
            StartCoroutine(retroalimentar());
        }
        else if (collision.CompareTag("Reverb3"))
        {
            vidas = vidas - 10;
            Debug.Log(vidas);
            StartCoroutine(retroalimentar());
        }
        else if (collision.CompareTag("Simple"))
        {
            vidas = vidas - 30;
            Debug.Log(vidas);
            StartCoroutine(retroalimentar());
        }
        else if (collision.CompareTag("Overdrive"))
        {
            vidas = vidas - 70;
            Debug.Log(vidas);
            StartCoroutine(retroalimentar());
        }
        else if (collision.CompareTag("Distortion"))
        {
            vidas = vidas - 60;
            Debug.Log(vidas);
            StartCoroutine(retroalimentar());
        }
        else if (collision.CompareTag("GSimple"))
        {
            vidas = vidas - 30;
            Debug.Log(vidas);
            StartCoroutine(retroalimentar());

        }
        else if (collision.CompareTag("GOverdrive"))
        {
            vidas = vidas - 250;
            Debug.Log(vidas);
            StartCoroutine(retroalimentar());
        }
        else if (collision.CompareTag("GDistortion"))
        {
            vidas = vidas - 210;
            Debug.Log(vidas);
            StartCoroutine(retroalimentar());
        }
        else if (collision.CompareTag("GChorus1"))
        {
            vidas = vidas - 100;
            Debug.Log(vidas);
            StartCoroutine(retroalimentar());
        }
        else if (collision.CompareTag("GChorus2"))
        {
            vidas = vidas - 50;
            Debug.Log(vidas);
            StartCoroutine(retroalimentar());
        }
        else if (collision.CompareTag("GReverb"))
        {
            vidas = vidas - 120;
            Debug.Log(vidas);
            StartCoroutine(retroalimentar());
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            
        }
    }

    IEnumerator retroalimentar()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.09f);
            spriteRenderer.color = Color.white;
            if (vidas < 1)
            {
                StartCoroutine(morir());
            }
        }
    }

    IEnumerator morir()
    {
        yield return new WaitForSeconds(0.1f);
        if(muerto == false)
        {
            GameObject nuevoCorazon = Instantiate(corazon);
            nuevoCorazon.transform.position = Calaco.transform.position;
        }
        muerto = true;
        if(Golpeador != null)
        {
            Calaco.transform.SetParent(null);
            GameObject auxiliar = Calaco;
            Calaco = Golpeador;
            auxiliar.transform.SetParent(Calaco.transform);
        }
        Collider2D cuerpo = Calaco.GetComponent<Collider2D>();
        Destroy(cuerpo);
        spriteRenderer.color = Color.black;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / duration);
            Color newColor = spriteRenderer.color;
            newColor.a = alpha;
            spriteRenderer.color = newColor;
            yield return null;
        }

        Destroy(Calaco);
    }
}
