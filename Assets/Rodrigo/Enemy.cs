using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public JugadorInput Victoria1;

    public AudioClip Putazo;

    [SerializeField] private SpriteRenderer Sprite1;
    [SerializeField] private SpriteRenderer Sprite2;
    [SerializeField] private SpriteRenderer Sprite3;
    [SerializeField] private SpriteRenderer Sprite4;
    [SerializeField] private SpriteRenderer Sprite5;

    public bool IsImmune { get; private set; } = false;
    public float fuerzaPutazo = 85;
    public float fuerzaPinchos = 85;
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            SonidosDanio.Instance.ejecutarSonido(Putazo);
            if (!IsImmune)
            {
                GameManager.Instance.perderVida();
            }

            Rigidbody2D playerRigidbody = GetComponent<Rigidbody2D>();

            if (playerRigidbody != null)
            {
                if(transform.position.x < other.transform.position.x)
                {
                    playerRigidbody.AddForce(new Vector2(-(fuerzaPutazo * fuerzaPutazo),0));
                }
                else
                {
                    playerRigidbody.AddForce(new Vector2(fuerzaPutazo * fuerzaPutazo, 0));
                }
            }

            StartCoroutine(ImmunityCoroutine());
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("pinchos"))
        {
            SonidosDanio.Instance.ejecutarSonido(Putazo);
            if (!IsImmune)
            {
                GameManager.Instance.perderVida();
            }

            Rigidbody2D playerRigidbody = GetComponent<Rigidbody2D>();

            if (playerRigidbody != null)
            {
                ContactPoint2D contact = other.contacts[0];
                if (transform.position.y < contact.point.y)
                {
                    if(Victoria1 != null)
                    {
                        if(Victoria1.orientationY > 0)
                        {
                            playerRigidbody.AddForce(new Vector2(0, -(fuerzaPutazo * fuerzaPutazo * 0.5f)));
                        }
                        else
                        {
                            playerRigidbody.AddForce(new Vector2(0, -fuerzaPutazo * fuerzaPutazo * fuerzaPinchos));
                        }
                    }

                }
                else
                {
                    if (Victoria1 != null)
                    {
                        if (Victoria1.orientationY > 0)
                        {
                            playerRigidbody.AddForce(new Vector2(0, fuerzaPutazo * fuerzaPutazo * fuerzaPinchos));
                        }
                        else
                        {
                            playerRigidbody.AddForce(new Vector2(0, (fuerzaPutazo * fuerzaPutazo * 0.5f)));
                        }
                    }
                }
            }

            StartCoroutine(ImmunityCoroutine());
        }
    }

    private IEnumerator ImmunityCoroutine()
    {
        IsImmune = true;
        
        Sprite1.color = Color.red;
        if(Sprite2 != null)
        {
            Sprite2.color = Color.red;
            Sprite3.color = Color.red;
            Sprite4.color = Color.red;
            Sprite5.color = Color.red;
        }
        yield return new WaitForSeconds(0.15f);
        Sprite1.color = Color.white;
        if (Sprite2 != null && Sprite3 != null)
        {
            Sprite2.color = Color.white;
            Sprite3.color = Color.white;
            Sprite4.color = Color.white;
            Sprite5.color = Color.white;
        }
        yield return new WaitForSeconds(0.5f);



        Sprite1.color = Color.red;
        if (Sprite2 != null)
        {
            Sprite2.color = Color.red;
            Sprite3.color = Color.red;
            Sprite4.color = Color.red;
            Sprite5.color = Color.red;
        }
        yield return new WaitForSeconds(0.15f);
        Sprite1.color = Color.white;
        if (Sprite2 != null && Sprite3 != null)
        {
            Sprite2.color = Color.white;
            Sprite3.color = Color.white;
            Sprite4.color = Color.white;
            Sprite5.color = Color.white;
        }
        yield return new WaitForSeconds(0.5f);



        Sprite1.color = Color.red;
        if (Sprite2 != null)
        {
            Sprite2.color = Color.red;
            Sprite3.color = Color.red;
            Sprite4.color = Color.red;
            Sprite5.color = Color.red;
        }
        yield return new WaitForSeconds(0.15f);
        Sprite1.color = Color.white;
        if (Sprite2 != null && Sprite3 != null)
        {
            Sprite2.color = Color.white;
            Sprite3.color = Color.white;
            Sprite4.color = Color.white;
            Sprite5.color = Color.white;
        }
        yield return new WaitForSeconds(0.5f);



        Sprite1.color = Color.red;
        if (Sprite2 != null)
        {
            Sprite2.color = Color.red;
            Sprite3.color = Color.red;
            Sprite4.color = Color.red;
            Sprite5.color = Color.red;
        }
        yield return new WaitForSeconds(0.15f);
        Sprite1.color = Color.white;
        if (Sprite2 != null && Sprite3 != null)
        {
            Sprite2.color = Color.white;
            Sprite3.color = Color.white;
            Sprite4.color = Color.white;
            Sprite5.color = Color.white;
        }
        yield return new WaitForSeconds(0.5f);



        Sprite1.color = Color.red;
        if (Sprite2 != null)
        {
            Sprite2.color = Color.red;
            Sprite3.color = Color.red;
            Sprite4.color = Color.red;
            Sprite5.color = Color.red;
        }
        yield return new WaitForSeconds(0.15f);
        Sprite1.color = Color.white;
        if (Sprite2 != null && Sprite3 != null)
        {
            Sprite2.color = Color.white;
            Sprite3.color = Color.white;
            Sprite4.color = Color.white;
            Sprite5.color = Color.white;
        }
        yield return new WaitForSeconds(0.5f);


        IsImmune = false;
    }
}