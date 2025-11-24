using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{

    //singleton
    public static EventManager Instance;
    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //CREACION DE LOS EVENTOS
    public UnityEvent OnBlockDestroyed;
    public UnityEvent OnLifesChanged;
    public UnityEvent OnBallLaunch;
    public UnityEvent OnBlocksFinished;



}
