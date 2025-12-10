using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class i18n
{

    //creamos el diccionario de las traducciones
    private Dictionary<string, string> translationsDictionary = new Dictionary<string, string>();

     public i18n()
     {
        
        this.ChangeLanguage("es");

     }



    public void ChangeLanguage(string language)
    {
        //cargamos el contenido del jSon (a partir de la ruta de unity Resources -> i18n -> idioma) 
        UnityEngine.TextAsset content = Resources.Load<UnityEngine.TextAsset>($"i18n/{language}");


        //metemo el contenido del jSOn en la lista creada TranslationsDTO
        TranslationsDTO translationsDTO = JsonUtility.FromJson<TranslationsDTO>(content.text);


        //llamamos al método de convertir la lista en diccionario (pasandole la lista tranlationsDTO
        this.translationsDictionary = this.ConvertToDictionary(translationsDTO.translations);

        Main.CustomEvents.OnLanguageChanged.Invoke();
    }



    //metodo para convetir la lista translationDTO a diccionario para poder coger el value a partir de la key
    private Dictionary<string, string> ConvertToDictionary(List<TranslateItem> translations)
    {
        //creamos el diccionario
        Dictionary<string, string> result = new Dictionary<string, string>();

        foreach (var translation in translations)
        {
            //para comprobar si hay claves duplicadas
            if (!result.TryAdd(translation.key, translation.value))
            {
                //TODO; Escribe mensage de error
            }
        }
        return result;
    }

    //devuelve el value a partir de la clave (key)
    public string Get(string key)
    {
        if (!this.translationsDictionary.TryGetValue(key, out string value))
        {
            return key;
        }

        return value;
    }
}
    







    

