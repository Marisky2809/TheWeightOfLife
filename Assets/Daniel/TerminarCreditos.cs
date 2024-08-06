using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TerminarCreditos : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(TiempoEspera());
    }

    private IEnumerator TiempoEspera()
    {
        yield return new WaitForSeconds(27f);
        SceneManager.LoadScene("MainMenu");
    }
}
