using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MenuPrincipal;
    public GameObject Controles;


    public void Jugar()
    {
        GameManager.Instance.ResetGameValues();
        SceneManager.LoadScene("Pantalla " + GameManager.Instance.Level);
       
        
        Debug.Log("jhghjg");

    }
    public void AbrirControles()
    {
        Controles.SetActive(true);
    }

    public void CerrarControles()
    {
        Controles.SetActive(false);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
