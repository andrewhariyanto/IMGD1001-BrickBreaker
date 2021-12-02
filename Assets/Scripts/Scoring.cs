using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public GameManager gameManager { get; private set; }
    public Text playerScoreText;
    public Text playerLivesText;

    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        playerScoreText.text = "Score: " + gameManager.score.ToString();
        playerLivesText.text = "Lives: " + gameManager.lives.ToString();
    }

    public void changeScore()
    {
        playerScoreText.text = "Score: " + gameManager.score.ToString();
        playerLivesText.text = "Lives: " + gameManager.lives.ToString();
    }

}
