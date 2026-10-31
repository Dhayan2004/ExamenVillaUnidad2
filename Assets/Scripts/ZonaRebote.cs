using UnityEngine;

public class ZonaRebote : MonoBehaviour
{
    public float impulsoX = 7f;
    public float impulsoY = 9f;

    void OnCollisionEnter2D(Collision2D choque)
    {
        MovimientoJugador jugador =
            choque.gameObject.GetComponent<MovimientoJugador>();

        if (jugador != null)
        {
            jugador.RecibirImpulso(
                new Vector2(impulsoX, impulsoY)
            );
        }
    }
}