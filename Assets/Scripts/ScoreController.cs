using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [Header("Dynamic")]
    public int score = 0;
    public Text uiText;
    // Start is called before the first frame update
    void Start()
    {
        score = LivesStatic.score;
    }
 /*
    // Update is called once per frame
    void Update()
    {
        uiText.text = $"Score: {score}";
    }

*/
   
    void Update()
    {
        UpdateScore();
    }
    

    private void UpdateScore()
    {
        score = LivesStatic.score;
        uiText.text = $"Score: {score}";
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            score += 10;
        }
    }
}
