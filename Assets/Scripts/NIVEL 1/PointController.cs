using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointController : MonoBehaviour
{

    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        this.text = GetComponent<TextMeshProUGUI>();
        EventManager.Instance.OnBlockDestroyed.AddListener(UpdateText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateText()
    {
        this.text.text = GameManager.Instance.Score.ToString();

    }
}
