using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoJugador : MonoBehaviour
{
    public float fuerzaMovimiento = 8f;
    public float fuerzaSalto = 7f;

    private Rigidbody2D rb;
    private Vector2 movimiento;
    private bool puedeSaltar = false;
    private GameObject apoyo;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputValue value)
    {
        movimiento = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed && puedeSaltar)
        {
            puedeSaltar = false;
            apoyo = null;

            rb.AddForce(
                Vector2.up * fuerzaSalto,
                ForceMode2D.Impulse
            );
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(
            Vector2.right * movimiento.x * fuerzaMovimiento
        );
    }

    public void RecibirImpulso(Vector2 impulso)
    {
        puedeSaltar = false;
        apoyo = null;

        rb.linearVelocity = Vector2.zero;

        rb.AddForce(
            impulso,
            ForceMode2D.Impulse
        );
    }

    void OnCollisionEnter2D(Collision2D choque)
    {
        float parteSuperior =
            choque.transform.position.y
            + choque.transform.localScale.y / 2f;

        if (choque.gameObject.name != "ZonaRebote"
            && transform.position.y > parteSuperior)
        {
            puedeSaltar = true;
            apoyo = choque.gameObject;
        }
    }

    void OnCollisionExit2D(Collision2D choque)
    {
        if (choque.gameObject == apoyo)
        {
            puedeSaltar = false;
            apoyo = null;
        }
    }
}