using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladrillos : MonoBehaviour
{
    [SerializeField] private int collisions;
    [SerializeField] private int points;


    /// <summary>
    /// destruye los ladrillos al chocar la pelota con ellos
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Pelota"))
        {
            collisions--;

            if (collisions == 0)
            {
                Destroy(gameObject);
            }


        }
    }
}
