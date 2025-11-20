using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ladrillos : MonoBehaviour
{
    [SerializeField] private LadrilloData data;


    private int collisions;
    private int points;
     

    private void Awake()
    {
                
        this.collisions= data.Collisions;
        this.points= data.Points;

        
    }


    private void Update()
    {
      
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
                EventManager.Instance.OnBlockDestroyed?.Invoke();
                GameManager.Instance.AddScore(this.points);

                Destroy(gameObject);
                
            }


        }
    }

    

    

}
