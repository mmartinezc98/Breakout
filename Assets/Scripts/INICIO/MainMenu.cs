using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject MenuPrincipal;
    public GameObject Controles;


    public void Jugar()
    {
        GameManager.Instance.EndLevel();


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
