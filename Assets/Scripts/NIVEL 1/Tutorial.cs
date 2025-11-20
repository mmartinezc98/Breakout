using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textoTutotial;

    
    void Start()
    {
        StartCoroutine("StartingTutorial");
        EventManager.Instance.OnBallLaunch.AddListener(UnsusbcribeEventBallLaunch);
    }
    
    /// <summary>
    /// pone el tutorial en pantalla al iniciar el nivel 1
    /// </summary>
    /// <returns></returns>
    private IEnumerator StartingTutorial()
    {
       
        yield return new WaitForSeconds(4f);
        _textoTutotial.text = "Pulsa ESPACIO para lanzar la bola";

    }


    /// <summary>
    /// detiene la corrutina del tutorial y lo oculta una vez lanzada la bola 
    /// </summary>
    public void UnsusbcribeEventBallLaunch()
    {
        StopCoroutine("StartingTutorial");

        _textoTutotial.text = "";

        EventManager.Instance.OnBallLaunch.RemoveListener(UnsusbcribeEventBallLaunch);

       
    }
}
