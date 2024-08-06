using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activador : MonoBehaviour
{
    public SistemaGuardado sistemaGuardado;
    public GameObject microUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ActDash"))
        {
            sistemaGuardado.partida.Dash = true;
            collision.gameObject.SetActive(false);
        }
        if (collision.CompareTag("ActGuitarra"))
        {
            sistemaGuardado.partida.Guitarra = true;
            collision.gameObject.SetActive(false);
        }
        if (collision.CompareTag("ActPedal"))
        {
            sistemaGuardado.partida.maximo = 1;
            sistemaGuardado.partida.minimo = 1;
            Debug.Log(sistemaGuardado.partida.maximo);
            sistemaGuardado.partida.iterador = sistemaGuardado.partida.maximo;
            collision.gameObject.SetActive(false);
        }
        if (collision.CompareTag("ActPedal2"))
        {
            sistemaGuardado.partida.maximo = 2;
            sistemaGuardado.partida.minimo = 1;
            sistemaGuardado.partida.iterador = sistemaGuardado.partida.maximo;
            collision.gameObject.SetActive(false);
        }
        if (collision.CompareTag("ActPedal3"))
        {
            sistemaGuardado.partida.maximo = 3;
            sistemaGuardado.partida.minimo = 1;
            sistemaGuardado.partida.iterador = sistemaGuardado.partida.maximo;
            collision.gameObject.SetActive(false);
        }
        if (collision.CompareTag("ActPedal4"))
        {
            sistemaGuardado.partida.maximo = 4;
            sistemaGuardado.partida.minimo = 1;
            sistemaGuardado.partida.iterador = sistemaGuardado.partida.maximo;
            collision.gameObject.SetActive(false);
        }
        if (collision.CompareTag("ActMicrofono"))
        {
            sistemaGuardado.partida.Grappling = true;
            collision.gameObject.SetActive(false);
            microUI.SetActive(true);
        }
    }
}
