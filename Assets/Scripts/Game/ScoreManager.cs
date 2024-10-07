using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    public TextMeshProUGUI scoreText;

    public static bool resetValue = false; // xác định reset các chỉ số khi trò chơi kết thúc

    void Update()
    {
        scoreText.text = "Score: " + score;
    }

    public static void AddScore(int amount)
    {
        score += amount;
    }

}