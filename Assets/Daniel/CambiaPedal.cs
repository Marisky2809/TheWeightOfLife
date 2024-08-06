using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CambiaPedal : MonoBehaviour
{
    public SistemaGuardado sistemaGuardado;
    [SerializeField] private AudioClip pedal;
    public void CambiarMas(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if(sistemaGuardado.partida.minimo < sistemaGuardado.partida.maximo)
            {
                ControladorSonido.Instance.ejecutarSonido(pedal);
            }
            if (sistemaGuardado.partida.iterador < sistemaGuardado.partida.maximo)
            {
                sistemaGuardado.partida.iterador++;
            }
            else
            {
                sistemaGuardado.partida.iterador = sistemaGuardado.partida.minimo;
            }
        }
    }
    public void CambiarMenos(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (sistemaGuardado.partida.minimo < sistemaGuardado.partida.maximo)
            {
                ControladorSonido.Instance.ejecutarSonido(pedal);
            }
            if (sistemaGuardado.partida.iterador > sistemaGuardado.partida.minimo)
            {
                sistemaGuardado.partida.iterador--;
            }
            else
            {
                sistemaGuardado.partida.iterador = sistemaGuardado.partida.maximo;
            }
        }
    }
}