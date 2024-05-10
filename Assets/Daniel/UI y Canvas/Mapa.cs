using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mapa : MonoBehaviour
{
    private bool MapActive;
    public GameObject MapaGrande;
    public GameObject HUD;

    private void Start()
    {
        MapActive = false;
        MapaGrande.SetActive(false);
        HUD.SetActive(true);
    }
    public void ActivarHud(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            MapActive = !MapActive;
            if (MapActive)
            {
                Time.timeScale = 0;
                MapaGrande.SetActive(true);
                HUD.SetActive(false);
            }
            else
            {
                Time.timeScale = 1;
                MapaGrande.SetActive(false);
                HUD.SetActive(true);
            }
        }
    }
}
