using System.Runtime.CompilerServices;
using UnityEngine;

public class Control_Pelota : MonoBehaviour
{
    [SerializeField] private Vector2 _startvelocity = new Vector2(1, 1); //el serializeField sirve para modificar la variable desde unity aunque sea privada
    [SerializeField] private float _velocity = 4f;

    private Rigidbody2D _rigidPelota;
    private bool _keyPush = true;

    private Vector3 _initialPosition;


    public GameObject father;



    void Start()
    {
        _rigidPelota = GetComponent<Rigidbody2D>(); //cogemos el rigidbody de la pelota y se lo asignamos a la variable creada
        _initialPosition = transform.position;


    }


    void Update()
    {
        

        startBoost();
    }



    /// <summary>
    /// dispara la bola al pulsar el espacio
    /// </summary>
    private void startBoost()
    {
        if (_keyPush) //esto seria si _keyPush es verdadero y !_keyPush es falso
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {

                _rigidPelota.velocity = _startvelocity * _velocity;

                transform.parent = null; //cuando se pulsa el espacio, la bola se desvincula del padre para que no siga su movimiento

                _keyPush = false;
            }

        }
    }


    /// <summary>
    /// cuando colisiona con la deadzone se resetea la posicion de la bola al inicio
    /// </summary>
    /// <param name="collision"></param>
    /// 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeadZone"))
        {

            _rigidPelota.velocity = Vector2.zero; //se resetea la velocidad de la bola a 0
            transform.position = _initialPosition; //se resetea a la posision inicial

            transform.SetParent(father.transform); //se vuelve a instanciar de la pala para que siga el movimiento
            _keyPush = true; //se vuelve a activar el poder darle al espacio 


        }
    }
}
