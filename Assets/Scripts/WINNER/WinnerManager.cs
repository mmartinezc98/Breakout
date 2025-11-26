using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerManager : MonoBehaviour
{
    public GameObject WinnerButton;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReturnMainMenu()
    {
       
        SceneManager.LoadScene(0);
    }
}
