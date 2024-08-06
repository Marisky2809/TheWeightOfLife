using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalacoGolpeador : MonoBehaviour
{
    public Metronomo metronomo;
    public CalacoMira miraScript;

    [SerializeField] private float VelocidadMovimiento;

    [SerializeField] private Transform[] puntosdemovimiento;

    [SerializeField] private float distanciaminima;

    [SerializeField] private GameObject mira;
    public float desplazamientoMira;
    private int numeroAleatorio = 0;
    private bool alternar = false;

    public GameObject putazo;
    private GameObject putazo2;
    private bool puedeGolpear = true;

    [SerializeField] private Animator animator;
    private void Update()
    {
        if (miraScript.orden)
        {
            
            Debug.Log("Simón");
            if (metronomo.autorizo && puedeGolpear)
            {
                puedeGolpear = false;
                StartCoroutine(duracionPutazo());
                miraScript.orden = false;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, puntosdemovimiento[numeroAleatorio].position, VelocidadMovimiento * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, puntosdemovimiento[numeroAleatorio].position) < distanciaminima)
        {

            alternar = !alternar;
            numeroAleatorio = alternar ? 1 : 0;
            girar();
        }
    }

    private void girar()
    {
        if (transform.position.x < puntosdemovimiento[numeroAleatorio].position.x)
        {
            mira.transform.position += Vector3.right * desplazamientoMira;
            animator.SetBool("Izquierda", false);
        }
        // Si la plataforma se mueve hacia la izquierda
        else
        {
            mira.transform.position += Vector3.left * desplazamientoMira;
            animator.SetBool("Izquierda", true);
        }
    }

    private IEnumerator duracionPutazo()
    {
        animator.SetBool("Golpeando", true);
        Debug.Log("Mamaste");
        yield return new WaitForSeconds(0.15f);
        putazo2 = Instantiate(putazo);
        putazo2.transform.parent = gameObject.transform;
        putazo2.transform.position = mira.transform.position;
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("Golpeando", false);
        putazo2.SetActive(false);
        puedeGolpear = true;
    }
}
