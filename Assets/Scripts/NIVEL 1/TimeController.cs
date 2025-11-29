using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    TextMeshProUGUI text;

    void Start()
    {
        this.text = GetComponent<TextMeshProUGUI>();
        EventManager.Instance.OnCronoStart.AddListener(UpdateTime);
       


        UpdateTime();
    }



    public void UpdateTime()
    {

        int minutos = Mathf.FloorToInt(GameManager.Instance.Crono / 60f);
        int segundos = Mathf.FloorToInt(GameManager.Instance.Crono % 60f);

        this.text.text = $"{minutos:00}:{segundos:00}";

    }
}
