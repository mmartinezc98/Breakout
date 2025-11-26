using TMPro;
using UnityEngine;

public class PointController : MonoBehaviour
{

    TextMeshProUGUI text;


    void Start()
    {
        this.text = GetComponent<TextMeshProUGUI>();
        EventManager.Instance.OnBlockDestroyed.AddListener(UpdateText);
        UpdateText();
    }

    void Update()
    {

    }

    public void UpdateText()
    {
        this.text.text = GameManager.Instance.Score.ToString();

    }
}
