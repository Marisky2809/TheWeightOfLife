using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{
    [SerializeField] private GameObject MarcaDeDialogo;

    [SerializeField] private GameObject PanelDialogo;

    [SerializeField] private TMP_Text TextoDelDialogo;

    private bool PlayerenRango;

    private bool DialogoIniciado;

    private int LineaINdex;

    private float TiempoDeTecleado = 0.05f;


    [SerializeField, TextArea (4,6)] private string[] LineasDeDialogo;

    void Update()
    {
        if (PlayerenRango && Input.GetButtonDown("Fire1"))
        {
            IniciarDialogo();
        }
        else if (TextoDelDialogo.text == LineasDeDialogo[LineaINdex])
        {
            SiguienteLineaDeDialogo();
        }
        else
        {
            StopAllCoroutines();
            TextoDelDialogo.text = LineasDeDialogo[LineaINdex];
        }
    }


    private void IniciarDialogo()
    {
        DialogoIniciado = true;
        PanelDialogo.SetActive(true);
        MarcaDeDialogo.SetActive(false);
        LineaINdex = 0;
        Time.timeScale = 0f;
        StartCoroutine(MostrarLinea());
    }

    private void SiguienteLineaDeDialogo()
    {
        LineaINdex++;
        if (LineaINdex < LineasDeDialogo.Length)
        {
            StartCoroutine(MostrarLinea());
        }
        else
        {
            DialogoIniciado = false;
            PanelDialogo.SetActive(false);
            MarcaDeDialogo.SetActive(true);
            Time.timeScale = 1f;
        }

    }


    private IEnumerator MostrarLinea()
    {
        TextoDelDialogo.text = string.Empty;
        foreach (char ch in LineasDeDialogo[LineaINdex])
        {
            TextoDelDialogo.text += ch;
            yield return new WaitForSecondsRealtime(TiempoDeTecleado);
        }
    }
 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerenRango = true;
            MarcaDeDialogo.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerenRango = false;
        MarcaDeDialogo.SetActive(false);
    }






}
