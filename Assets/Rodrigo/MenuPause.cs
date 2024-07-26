using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public GameObject ObjetoMenuPausa;
    public bool Pausa = false;

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if (Pausa == false)
            {
                ObjetoMenuPausa.SetActive(true);
                Pausa = true;

                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else if (Pausa == true) 
            {
                ObjetoMenuPausa.SetActive(false);
                Pausa = false;

                Time.timeScale = 1;
            }
        }
    }
    public void Resumir()
    {
        ObjetoMenuPausa.SetActive(false);
        Pausa = false;

        Time.timeScale = 1;
        Cursor.visible= false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Menu(string NombreMenu)
    {
        SceneManager.LoadScene(NombreMenu);
    }
}