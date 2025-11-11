using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _cronoText; //texto del UI donde se va a mostrar el tiempo transcurrido

    private float _time; //tiempo transcurrido
    private bool _levelFinished=false; //para controlar cuando se acaba el nivel y parar el contador

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_levelFinished) { return; } //si se acaba el nivel para de contar

        
        UpdateTime();
        
    }

    public void UpdateTime()
    {
        _time += Time.deltaTime; //le asigna el tiempo del deltaTime transcurrido a nuestra variable de tiempo transcurrido
        int minutes= Mathf.FloorToInt(_time)/60;
        int seconds= Mathf.FloorToInt(_time/60);
         _cronoText.text=$"{minutes} : {seconds}";
    }


}
