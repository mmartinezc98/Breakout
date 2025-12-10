using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TraslatableItem : MonoBehaviour
{
    //coge los textos le indiques de la escena (insertar este scrip en el objeto), le adjudica una Key (en unity y que luego se usa para linkear el texto con el del json)
    private Text _text;
    [SerializeField] private string _key;

    private void Awake()
    {
        this._text = GetComponent<Text>();

        //nos suscribimos al evento de seleccion de idioma
        Main.CustomEvents.OnLanguageChanged.AddListener(UpdateText);
    }
   
    void Start()
    {      
        this.UpdateText();
    }


    private void UpdateText()
    {
        this._text.text = Main.i18n.Get(_key);
    }
}