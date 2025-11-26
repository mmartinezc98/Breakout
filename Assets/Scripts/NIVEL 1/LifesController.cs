using TMPro;
using UnityEngine;

public class LifesController : MonoBehaviour
{
    TextMeshProUGUI text;

    void Start()
    {
        this.text = GetComponent<TextMeshProUGUI>();
        EventManager.Instance.OnLifesChanged.AddListener(LifesTextUpdate);
        LifesTextUpdate();
    }

    void Update()
    {

    }

    public void LifesTextUpdate()
    {

        this.text.text = GameManager.Instance.Lifes.ToString();
    }
}
