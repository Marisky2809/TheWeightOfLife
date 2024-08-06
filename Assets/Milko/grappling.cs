using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class grappling : MonoBehaviour
{
    public SistemaGuardado sistemaGuardado;
    public JugadorInput jugador;
    public Animator anim;

    [SerializeField] private float grappleLength;
    [SerializeField] private LayerMask grappleLayer;
    [SerializeField] public LineRenderer rope;

    private Vector3 grapplePoint;
    private DistanceJoint2D joint;

    public GameObject mirilla;
    public GameObject puntero;
    public GameObject ancla;

    void Start()
    {
        joint = gameObject.GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        rope.enabled = false;
    }
    public void actionGrappling(InputAction.CallbackContext context)
    {
        if (context.performed && sistemaGuardado.partida.Grappling && jugador.puedeSaltar == false)
        {
            Vector3 directionToPuntero = puntero.transform.position - transform.position;
            Vector3 raycastDirection = directionToPuntero.normalized * grappleLength;
            RaycastHit2D hit = Physics2D.Raycast(
                origin: transform.position,
                direction: raycastDirection,
                distance: grappleLength,
                layerMask: grappleLayer);

            if (hit.collider != null)
            {
                anim.SetBool("Grappling", true);
                grapplePoint = hit.point;
                grapplePoint.z = 0;
                joint.connectedAnchor = grapplePoint;
                joint.enabled = true;
                joint.distance = Vector2.Distance(transform.position, puntero.transform.position);
                rope.SetPosition(0, grapplePoint);
                rope.SetPosition(1, transform.position);
                rope.enabled = true;
                ancla.transform.position = grapplePoint;
            }
        }
        if (context.canceled)
        {
            joint.enabled = false;
            rope.enabled = false;
            anim.SetBool("Grappling", false);
        }
    }

    void Update()
    {
        if (rope.enabled == true)
        {
            rope.SetPosition(1, transform.position);
        }

        if(sistemaGuardado.partida.Grappling && jugador.puedeSaltar == false && rope.enabled == false)
        {
            mirilla.SetActive(true);
        }
        else
        {
            mirilla.SetActive(false);
        }
    }
}
