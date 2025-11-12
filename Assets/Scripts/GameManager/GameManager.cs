using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{
        
    public static GameManager Instance; //para poder llamar al game manager desde otros scripts GameManager.Instance.Metodo();

    //NIVEL EN EL QUE ESTAMOS
    //private float _nivel;

    //CRONOMETRO
    private float _time=0f; //tiempo transcurrido
    [SerializeField] private TextMeshProUGUI _cronoText; //texto del UI donde se va a mostrar el tiempo transcurrido

    //PUNTUACION
    private int _score=0;
    [SerializeField] private TextMeshProUGUI _scoreText;

    //VIDAS
    private int _lifes = 3;
    [SerializeField] private TextMeshProUGUI _lifesText;


    private void Awake()
    {
        // Singleton: asegura que solo haya un GameManager 
        if (Instance != null && Instance != this) //si la instancia ya existe y es diferente a la nueva, destruye la nueva
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }


   
    void Start()
    {
        StartCoroutine(TimeCounter());
    }

    
    void Update()
    {   

       
        
        
    }


    /// <summary>
    /// corrutina del contador del tiempo
    /// </summary>
    /// <returns></returns>
    IEnumerator TimeCounter()
    {
    

            while (true)
            {
                // Usa Time.deltaTime para que el contador siga el tiempo real (frame-independent)
                _time += Time.deltaTime;

                int minutos = Mathf.FloorToInt(_time / 60f);
                int segundos = Mathf.FloorToInt(_time % 60f);

                _cronoText.text = $"{minutos:00}:{segundos:00}";

                // Actualiza cada frame (más preciso). Si quieres actualizar menos, usa WaitForSeconds(0.1f)
                yield return null;
            }           
    }


    /// <summary>
    /// metodo para añadir la puntuacion al romper los bloques
    /// </summary>
    /// <param name="amount"></param>
    public void AddScore(int amount)
    {
        _score += amount;

        
        if (_scoreText != null)
            _scoreText.text = _score.ToString();
    }


    public void LifeCounter()
    {
        _lifes--;

        _lifesText.text= _lifes.ToString();

        if ( _lifes == 0 )
        {
            Debug.Log("Has perdido");

        }
        

    }


}
