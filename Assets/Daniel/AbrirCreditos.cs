using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AbrirCreditos : MonoBehaviour
{
    [SerializeField] Image fadePanel;
    public GameObject Dialogo;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(TiempoEspera());
        }
    }

    private IEnumerator TiempoEspera()
    {
        yield return new WaitForSeconds(6f);
        Dialogo.SetActive(false);
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Credits");
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
}
