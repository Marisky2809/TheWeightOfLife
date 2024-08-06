using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.U2D.Animation;
using UnityEngine.Windows;

public class RadialMenu : MonoBehaviour
{
    [SerializeField] private AudioClip EncenderGuitarra;
    [SerializeField] private AudioClip EncenderBajo;

    public Guitarrazo guitarrazo;
    public GameObject fuegoBajo;
    public GameObject fuegoGuitarra;

    public GameObject fuegoBajo2;
    public GameObject fuegoGuitarra2;

    public RotarArma arma;
    public SistemaGuardado sistemaGuardado;

    public JugadorInput bajo;
    public JugadorInput guitarra;
    public JugadorInput baquetas;

    public SpriteRenderer guitarrista;

    public GameObject VictoriaBajo;
    public GameObject VictoriaGuitarra;
    public GameObject VictoriaBaquetas;
    public GameObject PuntoCamara;

    public Transform center;
    public Transform selectObject;
    private Vector3 VicPosicion;

    private float Gravedad = 1;

    private bool bajoActivo;

    private bool puedeCambiar = true;

    public GameObject guitarraUI;
    public GameObject bajoUI;
    public GameObject microUI;
    void Start()
    {
        bajoActivo = true;
        bajoUI.SetActive(true);
        guitarraUI.SetActive(false);
    }

    public void RotarArma(InputAction.CallbackContext context)
    {
        if (bajoActivo && sistemaGuardado.partida.Guitarra && puedeCambiar)
        {
            cambioGuitarra();
            ControladorSonido.Instance.ejecutarSonido(EncenderGuitarra);
        }
        else if(bajoActivo && sistemaGuardado.partida.Guitarra == false){
            Debug.Log("No se puede hacer nada, carnal");
        }
        else if(bajoActivo == false && puedeCambiar && guitarrazo.puedeGolpear)
        {
            cambioBajo();
            ControladorSonido.Instance.ejecutarSonido(EncenderBajo);
        }
    }
    private void cambioGuitarra()
    {
        fuegoGuitarra2 = Instantiate(fuegoGuitarra);
        VicPosicion = VictoriaBajo.transform.position;
        fuegoGuitarra2.transform.position = VicPosicion;
        if (bajo.rb.gravityScale < 0)
        {
            fuegoGuitarra2.GetComponent<SpriteRenderer>().flipY = true;
        }


        bajoActivo = false;
        PuntoCamara.transform.SetParent(null);
        StartCoroutine(ActivarGuitarra());
        guitarraUI.SetActive(true);
        if (sistemaGuardado.partida.Grappling)
        {
            microUI.SetActive(true);
        }
        bajoUI.SetActive(false);
    }
    private void cambioBajo()
    {
        

        fuegoBajo2 = Instantiate(fuegoBajo);
        VicPosicion = VictoriaGuitarra.transform.position;
        fuegoBajo2.transform.position = VicPosicion;
        if (guitarra.rb.gravityScale < 0)
        {
            fuegoBajo2.GetComponent<SpriteRenderer>().flipY = true;
        }

        bajoActivo = true;
        PuntoCamara.transform.SetParent(null);
        StartCoroutine(ActivarBajo());

        guitarraUI.SetActive(false);
        bajoUI.SetActive(true);
    }

    public IEnumerator ActivarGuitarra()
    {
        puedeCambiar = false;
        yield return new WaitForSeconds(0.1f);
        if (VictoriaBajo != null)
        {
            Gravedad = bajo.rb.gravityScale;
            VicPosicion = VictoriaBajo.transform.position;
            VictoriaBajo.SetActive(false);
        }

        if (Gravedad != guitarra.rb.gravityScale)
        {
            guitarra.orientationY *= -1;
            guitarra.rb.gravityScale *= -1;
            guitarra.feet.transform.position += Vector3.down * 1.8f * guitarra.orientationY;
            guitarra.guitarrista.transform.localScale = new Vector3(1, 1 * guitarra.orientationY, 1);
        }

        yield return new WaitForSeconds(0.1f);
        VictoriaGuitarra.SetActive(true);
        VictoriaGuitarra.transform.position = VicPosicion;
        VicPosicion.x = PuntoCamara.transform.position.x;
        PuntoCamara.transform.SetParent(VictoriaGuitarra.transform);
        Debug.Log("Sí se hizo");

        yield return new WaitForSeconds(0.6f);
        Destroy(fuegoGuitarra2);

        yield return new WaitForSeconds(0.5f);
        puedeCambiar = true;
    }

    public IEnumerator ActivarBajo()
    {
        puedeCambiar = false;
        yield return new WaitForSeconds(0.1f);
        
        bajoActivo = true;
        PuntoCamara.transform.SetParent(null);
        if (VictoriaGuitarra != null)
        {
            Gravedad = guitarra.rb.gravityScale;
            VicPosicion = VictoriaGuitarra.transform.position;
            VictoriaGuitarra.SetActive(false);
        }
        if (Gravedad != bajo.rb.gravityScale)
        {
            bajo.orientationY *= -1;
            bajo.rb.gravityScale *= -1;
            bajo.feet.transform.position += Vector3.down * 1.8f * bajo.orientationY;
            bajo.SpritesVic.transform.localScale = new Vector3(1, 1 * bajo.orientationY, 1);
            bajo.spriteRenderer.flipY = !bajo.spriteRenderer.flipY;
        }

        VictoriaBajo.SetActive(true);
        VicPosicion.x = PuntoCamara.transform.position.x;
        VictoriaBajo.transform.position = VicPosicion;
        PuntoCamara.transform.SetParent(VictoriaBajo.transform);
        yield return new WaitForSeconds(0.1f);
        PuntoCamara.transform.position = VictoriaBajo.transform.position;
        Debug.Log("Sí se hizo");

        /*
        yield return new WaitForSeconds(0.1f);
        arma.voltearDerecha();
        yield return new WaitForSeconds(0.1f);
        
        yield return new WaitForSeconds(1.5f);
        */

        yield return new WaitForSeconds(1f);
        Destroy(fuegoBajo2);

        yield return new WaitForSeconds(0.5f);
        
        puedeCambiar = true;
    }
}