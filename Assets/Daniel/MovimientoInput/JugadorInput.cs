using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class JugadorInput : MonoBehaviour
{
    public bool izquierda = false;

    public SistemaGuardado sistemaGuardado;
    public grappling grappling;

    public Guitarrazo guitarrazo;
    public SpriteRenderer guitarrista;
    [SerializeField] private GameObject ejeGrappling;
    public Rigidbody2D rb;

    public SpriteRenderer piernasQuietas;

    public GameObject SpritesVic;
    public SpriteRenderer spriteRenderer;

    private GameObject gravitoso;

    public float tiempoCamara = 0.5f;
    public float desplazamiento = 10;

    private float guitarristaCam = 1;

    //Variables Dash
    [Header("Dash")][SerializeField] private float _dashingTime = 0.4f;
    [SerializeField] private float _dashForce = 15f;
    [SerializeField] private float _timeCanDash = 1f;
    private bool _canDash = true;
    private bool _dashing = false;

    [Header("Velocidad de movimiento")]
    //Variable que indica la velocidad horizontal
    static public float horizontal;
    //Variable para la orientación Vertical
    public int orientationY = 1;

    //Velocidad al correr
    [SerializeField] private float velocidad = 6;

    //Variables Salto
    [Header("Salto")]
    public bool puedeSaltar = true;
    public bool segundoSalto = true;
    [SerializeField] private float fuerzaSalto = 10f;
    public GameObject feet;

    //Foco de la cámara
    [Header("Para mover la cámara")]
    public GameObject Foco;
    private bool moviendoC = false;

    public Animator animator;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            _dashing = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gravedad"))
        {
            GravityAction();
            gravitoso = collision.gameObject;
            gravitoso.SetActive(false);
            StartCoroutine(ActivarGravitoso());
        }
    }
    void Update()
    {
        //movimiento
        if (guitarrazo.puedeGolpear)
        {
            transform.Translate(Vector3.right * horizontal * velocidad * Time.deltaTime);
        }
        
        //Espejear Sprite
        if (horizontal < 0 && guitarrazo.puedeGolpear)
        {
            izquierda = true;
            spriteRenderer.flipX = true;
            RotarArma.rotable = true;
            if (velocidad != 0)
            {
                if (animator != null)
                {
                    animator.SetBool("Running", true);
                    if(piernasQuietas != null)
                    {
                        piernasQuietas.enabled = false;
                    }
                }
            }
        }
        else if (horizontal > 0 && guitarrazo.puedeGolpear)
        {
            izquierda = false;
            spriteRenderer.flipX = false;
            RotarArma.rotable = false;
            if (velocidad != 0)
            {
                if (animator != null)
                {
                    animator.SetBool("Running", true);
                    if (piernasQuietas != null)
                    {
                        piernasQuietas.enabled = false;
                    }
                }
            }
        }
        else
        {
            if (animator != null)
            {
                animator.SetBool("Running", false);
                if (piernasQuietas != null && puedeSaltar && segundoSalto)
                {
                    piernasQuietas.enabled = true;
                }
            }
        }
        if(grappling != null)
        if (grappling.rope.enabled == true)
        {
            velocidad = 0;
        }
        else
        {
            velocidad = 6;
        }
        //Dash
        if (_dashing)
        {
            transform.Translate(Vector3.right * horizontal * _dashForce * 2 * Time.deltaTime);
            rb.velocity = new Vector3(0, 0, 0);
        }

        if (moviendoC)
        {
            if (orientationY < 0)
            {
                Foco.transform.position += Vector3.down * 10f * Time.deltaTime;

            }
            else
            {
                Foco.transform.position += Vector3.up * 10f * Time.deltaTime;
            }
        }

    }
    public void Salto(InputAction.CallbackContext context)
    {
        if(context.performed && (puedeSaltar || segundoSalto) && guitarrazo.puedeGolpear)
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto * orientationY);
            if (puedeSaltar == false)
            {
                if (piernasQuietas != null)
                {
                    piernasQuietas.enabled = false;
                }
                segundoSalto = false;
                if (animator != null)
                {
                    animator.SetBool("Piso", false);
                    animator.SetBool("Jumping", false);
                    animator.SetBool("SegundoSalto", true);
                }
            }
            else
            {
                if (piernasQuietas != null)
                {
                    piernasQuietas.enabled = false;
                }
                puedeSaltar = false;
                if (animator != null)
                {
                    
                    animator.SetBool("Piso", false);
                    animator.SetBool("Jumping", true);
                }

            }
        }
        if(context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 1f);
        }
    }
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void GravityChange(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("JAsjasj");
            //GravityAction();
        }
    }

    public void Dashing(InputAction.CallbackContext context)
    {
        if (context.performed && _canDash && sistemaGuardado.partida.Dash)
        {
            StartCoroutine(ActionDash());
        }
    }
    private IEnumerator ActionDash()
    {
        _canDash = false;
        rb.gravityScale = rb.gravityScale * 0.01f;
        _dashing = true;
        yield return new WaitForSeconds(_dashingTime);
        _dashing = false;
        rb.gravityScale *= 100;
        yield return new WaitForSeconds(_timeCanDash);
        _canDash = true;
    }
    public void StopMovement(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            velocidad = 0;
            if (animator != null)
            {
                animator.SetBool("Running", false);
                if (piernasQuietas != null && puedeSaltar)
                {
                    piernasQuietas.enabled = true;
                }
            }
        }
        else
        {
            velocidad = 6;
        }
    }

    public IEnumerator moverCamarita()
    {
        moviendoC = true;
        yield return new WaitForSeconds(0.5f);
        moviendoC = false;
    }

    public IEnumerator ActivarGravitoso()
    {
        yield return new WaitForSeconds(2.5f);
        gravitoso.SetActive(true);
    }

    public void GravityAction()
    {
        orientationY *= -1;
        rb.gravityScale *= -1;
        SpritesVic.transform.localScale = new Vector3(1, 1 * orientationY, 1);
        feet.transform.position += Vector3.down * 1.8f * orientationY;
        //StartCoroutine(moverCamarita());
        spriteRenderer.flipY = !spriteRenderer.flipY;
        if(guitarrista != null)
        {
            guitarrista.flipY = !guitarrista.flipY;
        }
    }
}
