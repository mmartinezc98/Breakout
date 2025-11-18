using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
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
    public UnityEvent<int> OnBlockDestroyed;
    public UnityEvent OnLifesChanged;

   

}
