using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HUD : MonoBehaviour
{
    public GameObject[] vidas;
    public GameObject[] CDs;
    public SistemaGuardado sistemaGuardado;

    private void Start()
    {
        if (sistemaGuardado.partida.vidas < 6)
        {
            vidas[5].SetActive(false);
        }
        if (sistemaGuardado.partida.vidas < 5)
        {
            vidas[4].SetActive(false);
        }
        if (sistemaGuardado.partida.vidas < 4)
        {
            vidas[3].SetActive(false);
        }
        if (sistemaGuardado.partida.vidas < 3)
        {
            vidas[2].SetActive(false);
        }
        if(sistemaGuardado.partida.vidas < 2)
        {
            vidas[1].SetActive(false);
        }
    }

    public void desactivarVida(int indice)
    {
        vidas[indice].SetActive(false);
    }

    public void activarVida(int indice)
    {
        vidas[indice].SetActive(true);
    }

    public void desactivarCDs()
    {
        CDs[0].SetActive(false);
        CDs[1].SetActive(false);
        CDs[2].SetActive(false);
    }

    public void activarCD(int indice)
    {
        CDs[indice].SetActive(true);
    }
}
