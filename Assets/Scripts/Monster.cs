using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ShouldDie(collision))
        {
            Destroy(gameObject);
        }
        ;
    }

    private bool ShouldDie(Collision2D collision)
    {
        // Devuelve verdadero si colisiono con el pajaro
        bool isBird = collision.gameObject.GetComponent<Bird>();

        if (isBird)
        {
            return true;
        }

        float crushThreshold = -0.5f;
        // Array con info de los puntos de contacto
        bool isCrushed = collision.contacts[0].normal.y < crushThreshold;// Primer elemento por casi siempre hay un unico contacto, cogemos el vector normal y,
                                                                         // y comprobamos que sea menor que -0.5, para saber si es aplastado
        if (isCrushed)
        {
            return true;
        }

        return false; 
    }
}
