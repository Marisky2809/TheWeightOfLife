using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioClip piano;
    public Vector3 Checkpoint;
    [SerializeField] Image fadePanel; // Referencia al panel negro de tipo Image
    [SerializeField] private GameObject Victoria1;
    [SerializeField] private GameObject Victoria2;
    public static GameManager Instance { get; private set; }
    [SerializeField] SistemaGuardado sistema_guardado;
    public int MaxVidas = 3;
    public HUD hud;
    public int CDs = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Mas de un GameManager en escena");
        }
    }

    public void perderVida()
    {
        if (sistema_guardado.partida.vidas > 0)
        {
            sistema_guardado.partida.vidas -= 1;
            if (sistema_guardado.partida.vidas == 0)
            {
                StartCoroutine(FadeEffect());
            }
            hud.desactivarVida(sistema_guardado.partida.vidas);
        }
      
      
    }
    public bool recuperarVida()
    {
        if(sistema_guardado.partida.vidas == MaxVidas)
        {
            return false;
        }
        hud.activarVida(sistema_guardado.partida.vidas);
        sistema_guardado.partida.vidas += 1;
        return true;
    }


    private IEnumerator FadeEffect()
    {
        yield return StartCoroutine(FadeOut());
        ControladorSonido.Instance.ejecutarSonido(piano);
        if (Victoria1 != null)
        {
            Victoria1.transform.position = Checkpoint;
        }
        if(Victoria2 != null)
        {
            Victoria2.transform.position = Checkpoint;
        }
        recuperarVida();

        yield return StartCoroutine(FadeIn());
    }

    private IEnumerator FadeOut()
    {
        float duration = 1f; // Duración de un segundo
        float elapsedTime = 0f;

        Color color = fadePanel.color;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, elapsedTime / duration);
            fadePanel.color = color;
            yield return null;
        }
        color.a = 1f;
        
        fadePanel.color = color;
    }

    private IEnumerator FadeIn()
    {
        float duration = 3f; // Duración de un segundo
        float elapsedTime = 0f;

        Color color = fadePanel.color;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, elapsedTime / duration);
            fadePanel.color = color;
            yield return null;
        }
        color.a = 0f;
        fadePanel.color = color;
    }
}
