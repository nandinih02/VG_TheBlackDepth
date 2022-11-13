using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [Header("Dynamic")]
    public int score = 0;

    public TextMeshProUGUI uiText;

    // Start is called before the first frame update
    void Start()
    {

        uiText = FindObjectOfType<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = "Score:" + score.ToString();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            score += 10;
        }
    }
}
