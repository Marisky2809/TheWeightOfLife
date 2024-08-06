using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public Vector3 Farias;
    public float velocidad;

    private void Update()
    {
        transform.position += Farias.normalized * velocidad * Time.deltaTime;
    }
}
