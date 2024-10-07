using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public float timeLimit = 30f;
    public float remainingTime;

    public TextMeshProUGUI timerText;

    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;
    public GameObject gemSpawner;

    public static bool isGameOver = false;
    public static bool resetValue = false; // xác định reset các chỉ số khi trò chơi kết thúc



    void Start() // đếm giờ khi trò chơi bắt đầu
    {
        remainingTime = timeLimit; //thời gian còn lại tại thời điểm bắt đầu bằng 30s (thời lượng của trò chơi)
        StartCoroutine(CountdownTimer());
        // là một phương thức nâng cao để gọi hàm CountdownTimer
        // nhằm cho phép đồng hồ chạy song song, tiếp tục đếm khi chuyển qua frame mới và kết thúc ở frame mới khi đạt đúng thời gian
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingTime <= 0)
        {
            isGameOver = true;
            GameOver();

            // Replay
            // TODO: change into load scene
            if (Input.GetKeyDown(KeyCode.Return))
            {
                isGameOver = false;
                resetValue = true; // reset giá trị của biến resetValue

                remainingTime = timeLimit;
                StartCoroutine(CountdownTimer());

                ScoreManager.score = 0;
                gameOverPanel.SetActive(false);
                gemSpawner.SetActive(true);
            }
        }
        timerText.text = "Time: " + Mathf.CeilToInt(remainingTime); //Mathf.CeilToInt(remainingTime) làm tròn số nguyên dương

    }

    private IEnumerator CountdownTimer()
    {
        while (remainingTime > 0)
        {
            yield return new WaitForSeconds(1f);
            remainingTime--;
        }
    }

    private void GameOver()
    {
        gameOverText.text = "Game Over!\nScore: " + ScoreManager.score;
        gameOverPanel.SetActive(true);
        gemSpawner.SetActive(false);
    }
}
