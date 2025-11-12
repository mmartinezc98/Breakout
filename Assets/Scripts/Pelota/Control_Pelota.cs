using System.Runtime.CompilerServices;
using UnityEngine;

public class Control_Pelota : MonoBehaviour
{
    [SerializeField] private Vector2 _startvelocity = new Vector2(1, 1); //el serializeField sirve para modificar la variable desde unity aunque sea privada
    [SerializeField] private float _velocity = 4f;

    private Rigidbody2D _rigidPelota;
    private bool _keyPush = true;

    //ARREGLAR BUG PELOTA CUANDO SE MUEVE SOLO VERTICAL O SOLO HORIZONTAL
    private float _xVelocityMin = 0.3f;
    private float _xAdjust = 0.4f;

    private float _yVelocityMin = 0.3f;
    private float _yAjust = 0.4f;


    private Vector3 _initialPosition;
    private Vector3 _offset = new Vector3(0, 0.25f,0);


    public GameObject father;



    void Start()
    {
        _rigidPelota = GetComponent<Rigidbody2D>(); //cogemos el rigidbody de la pelota y se lo asignamos a la variable creada
        _initialPosition = transform.position;

        

    }


    void Update()
    {     
        
        startBoost();
        MovementFix();
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
            GameManager.Instance.LifeCounter();

            _rigidPelota.velocity = Vector2.zero; //se resetea la velocidad de la bola a 0
             //se resetea a la posision inicial
            
            transform.SetParent(father.transform); //se vuelve a instanciar de la pala para que siga el movimiento
            transform.position = father.transform.position + _offset;

            _keyPush = true; //se vuelve a activar el poder darle al espacio 

        }    
        

    }

    /// <summary>
    /// para evitar que la pelota quede moviendose solo en el eje y
    /// </summary>
    private void MovementFix()
    {

        //si la velocidad en x es menor que el minimo asignado arriba, da un impulso haca la izquierda o derecha

        if(Mathf.Abs(_rigidPelota.velocity.x)< _xVelocityMin)
        {
            float direccion = Random.value < 0.5f ? -1f : 1f; // izquierda o derecha

            _rigidPelota.velocity += new Vector2(_xAdjust * direccion, _rigidPelota.velocity.y).normalized * _rigidPelota.velocity.magnitude;

        }

        if (Mathf.Abs(_rigidPelota.velocity.y) < _yVelocityMin)
        {
            float direccion = Random.value < 0.5f ? -1f : 1f; // izquierda o derecha

            _rigidPelota.velocity += new Vector2(_rigidPelota.velocity.x, _yAjust * direccion).normalized * _rigidPelota.velocity.magnitude;

        }


    } 


}

