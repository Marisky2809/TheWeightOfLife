using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Retroceso : MonoBehaviour
{ 
    private Rigidbody rb2d;

    public bool SepuedeMover = true;

    [SerializeField] private Vector2 VelocidadRebote;


    private void Rebote(Vector2 puntoGolpe)

    {
        rb2d.velocity = new Vector2(-VelocidadRebote.x * puntoGolpe.x, VelocidadRebote.y);
    }

    //esta parte es donde se va a poner el if en el movimiento de Victoria
    //Solo agarra el if y el salto, lo demas seria cambiar variables y listo
    private void Movimiento()
    {
        if (SepuedeMover)
        {
            Movimiento(Movimientohorizontal * Time.fixedDeltaTime, salto);
        }
        salto = false;
    }



   
}
