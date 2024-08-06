using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosDanio : MonoBehaviour
{
    public static SonidosDanio Instance;

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
