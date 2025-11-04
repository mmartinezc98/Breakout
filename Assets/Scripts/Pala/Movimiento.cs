using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    float minPosition = 0f;
    float maxPosition = 0f;
    public float Velocity = 2f;

    public GameObject leftWall;
    public GameObject rightWall;

    private void Awake()
    {
        
    }
 
    void Start()
    {
        mapLimits();
    }


    void Update()
    {
        // MoveObjectTranslate();

        MoveObjectPosition();
    }



   /* private void MoveObjectTranslate()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        Vector3 movementVector = new Vector3();

        movementVector.x= horizontalMove;
        movementVector.y = 0;
        movementVector.z= 0;


        //this._transform.Translate(movementVector.normalized * Velocity * Time.deltaTime);

    }*/


    /// <summary>
    /// calcula los limites del mapa usando las posiciones globlales de las 
    /// paredes izquierda y derecha y la pala y lo que miden los objetos en el eje x
    /// </summary>
     void mapLimits()

     { 


      minPosition = leftWall.transform.position.x + (leftWall.transform.localScale.x / 2) + (this.transform.localScale.x / 2);
      maxPosition = rightWall.transform.position.x - (rightWall.transform.localScale.x / 2) - (this.transform.localScale.x /2);  


      }

    /// <summary>
    /// mueve la pala horizontalmente y le asigna los valores maximo y minimo calculados 
    /// en el mapLimits para que no pueda traspasar los limites de la pantalla
    /// </summary>
    private void MoveObjectPosition()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");


        Vector2 newPosition = new Vector2();
        newPosition.y= this.transform.position.y;
        newPosition.x = this.transform.position.x + (inputHorizontal*Velocity*Time.deltaTime);



        newPosition.x= Mathf.Clamp(newPosition.x, this.minPosition, this.maxPosition); //hacer que la pala se mueva solo entre dos valores max y min (si se pasa te devuelve el valor max y min)
        
        this.transform.position = newPosition; //se le aplica al tranform del objeto la nueva posicion.

        //TO-DO. HACER QUE LA POSICION DE LA BOLA SE RESETEE EN MEDIO DE LA PALA
    }
}
