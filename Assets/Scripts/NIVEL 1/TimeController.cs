using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        this.text = GetComponent<TextMeshProUGUI>();
        EventManager.Instance.OnCronoStart.AddListener(UpdateTime);
        UpdateTime();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void UpdateTime()
    {

        int minutos = Mathf.FloorToInt(GameManager.Instance.Crono / 60f);
        int segundos = Mathf.FloorToInt(GameManager.Instance.Crono % 60f);

        this.text.text = $"{minutos:00}:{segundos:00}";

    }
}
