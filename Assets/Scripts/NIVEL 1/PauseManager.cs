using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] public GameObject MenuPausa;


    public bool pausa = false;

    void Start()
    {

    }


    void Update()
    {
        PausarJuego();
    }


    public void PausarJuego()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pausa == false)
        {

            MenuPausa.SetActive(true);
            pausa = true;
            Time.timeScale = 0f;

        }

        else if (Input.GetKeyDown(KeyCode.Escape) && pausa == true)
        {

            ReturnGameplay();

        }
    }


    public void ReturnGameplay()
    {
        MenuPausa.SetActive(false);
        pausa = false;
        Time.timeScale = 1f;
    }

    public void ReturnMainMenu()
    {
        pausa = false;
        Time.timeScale = 1f;

        SceneManager.LoadScene("Pantalla Inicio");
    }
}
