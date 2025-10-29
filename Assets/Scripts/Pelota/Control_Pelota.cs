using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Control_Pelota : MonoBehaviour
{
    private float _startVelocity = 4f;
    private Rigidbody2D _rigidPelota;
    private bool _keyPush = true;

    public GameObject father;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidPelota = GetComponent<Rigidbody2D>(); //cogemos el rigidbody de la pelota y se lo asignamos a la variable creada

       
    }

    // Update is called once per frame
    void Update()
    {
        startBoost();
    }

    /// <summary>
    /// dispara la bola al pulsar el espacio
    /// </summary>
    private void startBoost()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            _rigidPelota.velocity= transform.up * _startVelocity;

            transform.parent = null; //cuando se pulsa el espacio, la bola se desvincula del padre para que no siga su movimiento

            _keyPush = false; 
        }

    } //TO-DO HACER QUE AL PULSAR EL ESPACIO SE DESACTIVE EL PODER VOLVER A DARLE MAS VECES


    
}
