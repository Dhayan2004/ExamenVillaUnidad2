using UnityEngine;

public class ZonaDanio : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D otro)
    {
        MovimientoJugador jugador =
            otro.GetComponent<MovimientoJugador>();

        if (jugador != null)
        {
            Debug.Log("Perdiste");
        }
    }
}