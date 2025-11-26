using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public static GameOver Instance;

    public GameObject gameOver;

    public TextMeshProUGUI _scoreboardText;

    private void Awake()
    {
        Instance = this;
    }



    public void GameOverScreen()
    {
        gameOver.SetActive(true);


        ScoreManager.Instance.LoadScoreboard();

        for (int i = 0; i < ScoreManager.Instance.Scores.Count; i++)
        {
            _scoreboardText.text += $"{i + 1}. Puntos: {ScoreManager.Instance.Scores[i]}    Tiempo: {ScoreManager.Instance.Times[i]:0.0} \n";
            Debug.Log("Puntuacion");
        }

    }

    public void ReturnMainMenu()
    {
        

        SceneManager.LoadScene("Pantalla Inicio");
    }
}
