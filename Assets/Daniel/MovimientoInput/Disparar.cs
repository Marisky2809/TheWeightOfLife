using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Disparar : MonoBehaviour
{
    public SistemaGuardado sistemaGuardado;
    [SerializeField] CambiaPedal pedal;

    public AudioClip[,] NotasBajo = new AudioClip[5, 4];
    public AudioClip[] Clean = new AudioClip[4];
    public AudioClip[] Reverb = new AudioClip[4];
    public AudioClip[] OverDrive = new AudioClip[4];
    public AudioClip[] Chorus = new AudioClip[4];
    public AudioClip[] Distortion = new AudioClip[4];
    public AudioClip Trasteo;

    public Bala bala1;
    public Bala bala2;
    public Bala bala3;
    public Bala bala4;
    public Bala bala5;
    public GameObject Victoria1;
    public GameObject miraTemporal;
    public GameObject mirilla;
    public GameObject[] balas = new GameObject[5]; // Arreglo de balas
    public GameObject Auxbala; // Arreglo de auxiliares de balas
    public Transform spawner;
    public GameObject centro;
    public GameObject centroTemporal;

    private bool posibleDisparo = true;
    public float fuerza = 20f;
    public Vector3 direccionDisparo;
    public bool disparando = false;
    public Vector3 Rodrigo;

    public Metronomo metronomo;

    private bool ordenDisparo = false;

    private void Start()
    {
        NotasBajo[0, 0] = Clean[0];
        NotasBajo[0, 1] = Clean[1];
        NotasBajo[0, 2] = Clean[2];
        NotasBajo[0, 3] = Clean[3];

        NotasBajo[1, 0] = Reverb[0];
        NotasBajo[1, 1] = Reverb[1];
        NotasBajo[1, 2] = Reverb[2];
        NotasBajo[1, 3] = Reverb[3];

        NotasBajo[2, 0] = OverDrive[0];
        NotasBajo[2, 1] = OverDrive[1];
        NotasBajo[2, 2] = OverDrive[2];
        NotasBajo[2, 3] = OverDrive[3];

        NotasBajo[3, 0] = Chorus[0];
        NotasBajo[3, 1] = Chorus[1];
        NotasBajo[3, 2] = Chorus[2];
        NotasBajo[3, 3] = Chorus[3];

        NotasBajo[4, 0] = Distortion[0];
        NotasBajo[4, 1] = Distortion[1];
        NotasBajo[4, 2] = Distortion[2];
        NotasBajo[4, 3] = Distortion[3];
    }
    private void Update()
    {
        if (ordenDisparo)
        {
            accionDisparo();
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (Victoria1 != null)
        {
            if (context.canceled)
            {
                ordenDisparo = false;
                Debug.Log(ordenDisparo);
            }
            if (context.performed)
            {
                if (metronomo.autorizo)
                {
                    accionDisparo();
                    if (context.duration > 1.5f)
                    {
                        ordenDisparo = true;
                        Debug.Log(ordenDisparo);
                    }
                    else
                    {
                        ordenDisparo = false;
                    }
                }
                else
                {
                    ordenDisparo = false;
                    Debug.Log("Destiempo");
                    disparoMiado();
                }
            }
        }
    }

    private void accionDisparo()
    {
        if (posibleDisparo && (Victoria1 != null))
        {
            miraTemporal = Instantiate(mirilla, mirilla.transform.position, Quaternion.identity);
            centroTemporal = Instantiate(centro, centro.transform.position, Quaternion.identity);
            direccionDisparo = centroTemporal.transform.position;
            StartCoroutine(Disparando());
            Rodrigo = (direccionDisparo - miraTemporal.transform.position).normalized * Time.deltaTime * fuerza;
            bala1.Farias = Rodrigo;
            bala2.Farias = Rodrigo;
            bala3.Farias = Rodrigo;
            bala4.Farias = Rodrigo;
            bala5.Farias = Rodrigo;
            bala1.velocidad = 14f;
            bala2.velocidad = 14f;
            bala3.velocidad = 14f;
            bala4.velocidad = 14f;
            bala5.velocidad = 14f;
            Auxbala = Instantiate(balas[sistemaGuardado.partida.iterador], miraTemporal.transform.position, Quaternion.identity);
            Auxbala.transform.SetParent(miraTemporal.transform);
            Auxbala.transform.rotation = centro.transform.rotation;
            disparando = true;

            SonidosBajo.Instance.ejecutarSonido(NotasBajo[sistemaGuardado.partida.iterador, metronomo.Acorde]);

            Destroy(miraTemporal, 2f);
            Destroy(centroTemporal, 2f);
            if (Auxbala != null)
            {
                Destroy(Auxbala, 1.2f);
            }
        }
    }

    private void disparoMiado()
    {
        if (posibleDisparo && (Victoria1 != null))
        {
            miraTemporal = Instantiate(mirilla, mirilla.transform.position, Quaternion.identity);
            centroTemporal = Instantiate(centro, centro.transform.position, Quaternion.identity);
            direccionDisparo = centroTemporal.transform.position;
            StartCoroutine(Disparando());
            Rodrigo = (direccionDisparo - miraTemporal.transform.position).normalized * Time.deltaTime * fuerza;
            bala1.Farias = Rodrigo;
            bala2.Farias = Rodrigo;
            bala3.Farias = Rodrigo;
            bala4.Farias = Rodrigo;
            bala5.Farias = Rodrigo;
            bala1.velocidad = 5f;
            bala2.velocidad = 5f;
            bala3.velocidad = 5f;
            bala4.velocidad = 5f;
            bala5.velocidad = 5f;
            Auxbala = Instantiate(balas[sistemaGuardado.partida.iterador], miraTemporal.transform.position, Quaternion.identity);
            Auxbala.transform.SetParent(miraTemporal.transform);
            Auxbala.transform.rotation = centro.transform.rotation;
            Auxbala.transform.localScale = new Vector3(5f, 5f, 5f);
            disparando = true;

            SonidosError.Instance.ejecutarSonido(NotasBajo[sistemaGuardado.partida.iterador, metronomo.Acorde]);
            SonidosDanio.Instance.ejecutarSonido(Trasteo);
            Destroy(miraTemporal, 2f);
            Destroy(centroTemporal, 2f);
            if (Auxbala != null)
            {
                Destroy(Auxbala, 1f);
            }
        }
    }
    IEnumerator Disparando()
    {
        posibleDisparo = false;
        yield return new WaitForSeconds(0.35f);
        posibleDisparo = true;
    }
}
