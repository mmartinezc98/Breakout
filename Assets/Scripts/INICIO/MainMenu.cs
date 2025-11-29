using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MenuPrincipal;
    public GameObject Controles;


    /// <summary>
    /// Al pulsar el boton jugar resetea a los valores predeterminados la vida, tiempo y puntos y pasa al primer nivel
    /// </summary>
    public void Jugar()
    {
        GameManager.Instance.ResetGameValues();
        SceneManager.LoadScene("Pantalla " + GameManager.Instance.Level);    
        

    }

    /// <summary>
    /// abre la ventana de los controles
    /// </summary>
    public void AbrirControles()
    {
        Controles.SetActive(true);
    }

    /// <summary>
    /// vuelve al menu principal al darle al boton volver
    /// </summary>

    public void CerrarControles()
    {
        Controles.SetActive(false);
    }


    /// <summary>
    /// cierra la aplicacion.
    /// </summary>
    public void Salir()
    {
        Application.Quit();
    }
}
