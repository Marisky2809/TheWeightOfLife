using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosError : MonoBehaviour
{
    public static SonidosError Instance;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void ejecutarSonido(AudioClip sonido)
    {
        audioSource.PlayOneShot(sonido);
    }
}
