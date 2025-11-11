using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ladrillos : MonoBehaviour
{
    [SerializeField] private int collisions;
    [SerializeField] private int points;

   

    private void Update()
    {
        EndLevel();
    }


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

    private void EndLevel()
    {
        List<GameObject> BricksLeft = GameObject.FindGameObjectsWithTag("Ladrillo").ToList();
        if (BricksLeft.Count==0)
        {
            Debug.Log("Has pasado el nivel");

        }
    }
}
