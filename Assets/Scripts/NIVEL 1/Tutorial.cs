using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textoTutotial;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartingTutorial());
        EventManager.Instance.OnBallLaunch.AddListener(UnsusbcribeEventBallLaunch);
    }
    
    private IEnumerator StartingTutorial()
    {
       
        yield return new WaitForSeconds(4f);
        _textoTutotial.text = "Pulsa ESPACIO para lanzar la bola";


    }

    public void UnsusbcribeEventBallLaunch()
    {
        _textoTutotial.text = "";

        EventManager.Instance.OnBallLaunch.RemoveListener(UnsusbcribeEventBallLaunch);

    }
}
