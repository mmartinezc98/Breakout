using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance; //para poder llamar al game manager desde otros scripts GameManager.Instance.Metodo();

    private int _blocksNumber ;



    //NIVEL EN EL QUE ESTAMOS
    //private float _nivel;

    //CRONOMETRO
    private float _time = 0f; //tiempo transcurrido

    public float Crono => _time;


    //PUNTUACION
    private int _score = 0;

    public int Score => _score;

    //VIDAS
    private int _lifes = 3;

    public int Lifes => _lifes;

    //NIVEL
    private int _level = 1;
    public int Level => _level;


    private void Awake()
    {
        // Singleton: asegura que solo haya un GameManager 
         if (Instance != null && Instance != this) //si la instancia ya existe y es diferente a la nueva, destruye la nueva
         {
             Destroy(this.gameObject);
             return;
         }
         else
         {
            Instance = this;
            DontDestroyOnLoad(gameObject);
         }
         SceneManager.sceneLoaded += OnSceneLoaded;

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        GameManager.Instance.BlockReset();
        if(scene.name != "Pantalla Inicio")
        {
            EventManager.Instance.OnBallLaunch.AddListener(StartCounter);


        }
    }

    void Start()
    {

        //subcripcion al envento OnBlockDestroyed

        //EventManager.Instance.OnLifesChanged.AddListener(LifeCounter);
        EventManager.Instance.OnBlockDestroyed.AddListener(BlocksManager);
       

        List<GameObject> BricksLeft = GameObject.FindGameObjectsWithTag("Ladrillo").ToList();
        _blocksNumber = BricksLeft.Count;


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
            EventManager.Instance.OnCronoStart?.Invoke();
            // Actualiza cada frame (más preciso). Si quieres actualizar menos, usa WaitForSeconds(0.1f)
            yield return null;
        }
    }


    /// <summary>
    /// metodo para iniciar la corrutina del contador
    /// </summary>
    public void StartCounter()
    {


        StartCoroutine(TimeCounter());
        EventManager.Instance.OnBallLaunch.RemoveListener(StartCounter);
    }


    /// <summary>
    /// metodo para añadir la puntuacion al romper los bloques
    /// </summary>
    /// <param name="amount"></param>
    public void AddScore(int amount)
    {
        _score += amount;

        EventManager.Instance.OnBlockDestroyed?.Invoke();
        //if (_scoreText != null)
        //    _scoreText.text = _score.ToString();



    }

    /// <summary>
    /// contador de vidas
    /// </summary>
    public void LifeCounter()
    {

        _lifes--;
        EventManager.Instance.OnLifesChanged.Invoke();

        if (_lifes == 0)
        {
            GameOver.Instance.GameOverScreen();

            ScoreManager.Instance.AddRecord(_score, _time);

        }
    }

    /// <summary>
    /// cuenta los bloques que quedan en escena para cambiar de nivel
    /// </summary>
    public void BlocksManager()
    {
        _blocksNumber--;

        Debug.Log("bloques restantes:" + _blocksNumber);

        if (_blocksNumber <= 0)
        {
            Debug.Log("bloques rotos");
            EndLevel();

        }

    }

    /// <summary>
    /// cambio de nivel
    /// </summary>
    public void EndLevel()
    {
       
        int _levelIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(_levelIndex + 1);
        BlockReset();

    }
    public void BlockReset()
    {
        List<GameObject> BricksLeft = GameObject.FindGameObjectsWithTag("Ladrillo").ToList();
        _blocksNumber = BricksLeft.Count;

    }
    
    public void ResetGameValues()
    {
       
        BlockReset();
        _level = 1;
        _time = 0f;
        _lifes = 3;
        _score = 0;
        
    }
   
     
    




}
