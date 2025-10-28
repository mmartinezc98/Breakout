using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private Transform _transform;
    public float Velocity = 2f;

    private void Awake()
    {
        this._transform=this.gameObject.GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();
    }



    private void MoveObject()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        Vector3 movementVector = new Vector3();

        movementVector.x= horizontalMove;
        movementVector.y = 0;
        movementVector.z= 0;


        this._transform.Translate(movementVector.normalized * Velocity * Time.deltaTime);



    }
}
