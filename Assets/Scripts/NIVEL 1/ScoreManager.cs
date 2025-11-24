using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance;

    private const int _maxRegisters = 6;

    public List<int> Scores = new List<int>();
    public List<float> Times = new List<float>();

    private void Awake()
    {
        //LoadScoreboard();

        Instance = this;
    }


    void Start()
    {

    }

    /// <summary>
    /// carga las listas de puntos y tiempo
    /// </summary>
    public void LoadScoreboard()
    {
        Scores.Clear();
        Times.Clear();

        for (int i = 0; i < _maxRegisters; i++)
        {
            int s = PlayerPrefs.GetInt("Score_" + i, -1);
            float t = PlayerPrefs.GetFloat("Time_" + i, -1);

            if (s >= 0)        // Si hay un valor válido lo añadimos
            {
                Scores.Add(s);
                Times.Add(t);
            }
        }
    }

    private void InsertRecord(int score, float time)
    {
        // Insertamos en la posición correcta
        for (int i = 0; i < Scores.Count; i++)
        {
            if (score > Scores[i])
            {
                Scores.Insert(i, score);
                Times.Insert(i, time);
                TrimList();
                return;
            }
            Scores.Add(score);
            Times.Add(time);

            TrimList();
        }

    }
    public void AddRecord(int score, float time)
    {
        InsertRecord(score, time);
        SaveScoreboard();
    }

    private void TrimList()
    {

        if (Scores.Count > _maxRegisters)
            Scores.RemoveRange(_maxRegisters, Scores.Count - _maxRegisters);

        if (Times.Count > _maxRegisters)
            Times.RemoveRange(_maxRegisters, Times.Count - _maxRegisters);
    }

    private void SaveScoreboard()
    {
        for (int i = 0; i < _maxRegisters; i++)
        {
            PlayerPrefs.SetInt("Score_" + i, i < Scores.Count ? Scores[i] : 0);
            PlayerPrefs.SetFloat("Time_" + i, i < Times.Count ? Times[i] : 0);
        }

        PlayerPrefs.Save();
    }



}
