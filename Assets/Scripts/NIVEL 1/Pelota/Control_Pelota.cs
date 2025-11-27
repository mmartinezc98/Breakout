using UnityEngine;

public class Control_Pelota : MonoBehaviour
{
    [SerializeField] private Vector2 _startvelocity = new Vector2(1, 1); //el serializeField sirve para modificar la variable desde unity aunque sea privada
    [SerializeField] private float _velocity = 5f;

    private Rigidbody2D _rigidPelota;
    private bool _keyPush = true;






    private Vector3 _initialPosition;
    private Vector3 _offset = new Vector3(0, 0.25f, 0);


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
                EventManager.Instance.OnBallLaunch?.Invoke();

                _rigidPelota.velocity = (_startvelocity.normalized * _velocity);

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
            //EventManager.Instance.OnLifesChanged.Invoke();
            GameManager.Instance.LifeCounter();

            _rigidPelota.velocity = Vector2.zero; //se resetea la velocidad de la bola a 0
                                                  //se resetea a la posision inicial

            transform.SetParent(father.transform); //se vuelve a instanciar de la pala para que siga el movimiento
            transform.position = father.transform.position + _offset;

            _keyPush = true; //se vuelve a activar el poder darle al espacio 

        }


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Pala"))
        {
            //metodo para hacer que rebote la bola dependiendo de en que parte de la pala/player choque
            // Punto de colisión real
            Vector2 punto = collision.GetContact(0).point;

            // Centro de la pala
            Vector2 centroPala = collision.collider.bounds.center;

            // Desplazamiento del impacto respecto al centro (negativo = izquierda, positivo = derecha)
            float offsetX = punto.x - centroPala.x;

            // Normalizamos para obtener un valor entre -1 y 1
            float mitadAncho = collision.collider.bounds.size.x / 2f;
            float factor = offsetX / mitadAncho; // -1 = izquierda, 0 = centro, 1 = derecha

            // Control del ángulo horizontal. Multiplica para aumentar inclinación máxima.
            float bounceX = factor * 1.5f;

            // Dirección final del rebote
            Vector2 nuevaDireccion = new Vector2(bounceX, 1f).normalized;

            // Asignamos velocidad manteniendo tu velocidad base
            _rigidPelota.velocity = nuevaDireccion * _velocity;
        }

        MovementFix();

    }






    /// <summary>
    /// para evitar que la pelota quede moviendose solo en el eje y
    /// </summary>
    private void MovementFix()
    {

        float _VelocityMin = 0.3f;
        float _Adjust = 0.4f;
        if (_keyPush == false)
        {
            //si la velocidad en x es menor que el minimo asignado arriba, da un impulso haca la izquierda o derecha

            if (Mathf.Abs(_rigidPelota.velocity.x) <= _VelocityMin)
            {
                _Adjust = Random.value < 0.5f ? -_Adjust : _Adjust; // izquierda o derecha

                _rigidPelota.velocity += new Vector2(_Adjust, 0f);

            }

            //si la velocidad en y es menor que el minimo asignado arriba, da un impulso haca la izquierda o derecha

            if (Mathf.Abs(_rigidPelota.velocity.y) <= _VelocityMin)
            {
                _Adjust = Random.value < 0.5f ? -_Adjust : _Adjust; // izquierda o derecha

                _rigidPelota.velocity += new Vector2(0f, _Adjust);

            }

        }
    }


}

