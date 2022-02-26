using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] public PlayerController player;
    private int score;
   

    public void ScoreText()
    {
        scoreText.text = "Score:" + score;
    }
    public void AddPoints()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            score++;
        }
    }
}
