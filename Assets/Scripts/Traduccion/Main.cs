using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Main 
{
    //inicializamos la clase i18n, los eventos y la configuracion por defecto
    public static i18n i18n;
    public static CustomEvents CustomEvents;

    //configuracion de valores por defectos (idioma, dificultad)
    //public static CustomConfiguration Configuration; 

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]

    //inicializamos la clase i18n y los eventos
    public static void Start()
    {
        CustomEvents = new CustomEvents();
        i18n = new i18n();
        //Configuracion= new CustomConfigutation();
    }
}
