using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    //   public int slow = 2;    // Tốc độ giảm của nhân vật theo cấp số nhân
    public int pointEat = 1;
    public float timeEat = 5f;

    // public ScoreManager scoreManager;
    // public TimeManager timeManager;

    void Update()
    {
        if (TimeManager.isGameOver)
        {
            Destroy(gameObject);
            // gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Điều kiện kiểm tra thông tin của OTHER - đối tượng va chạm
        if (other.gameObject.CompareTag("Player"))  // Va chạm với đối tượng Player
        {
            ScoreManager.AddScore(-pointEat);

            TimeManager.remainingTime -= timeEat;

            // //Khai báo biến tên audioSource để gán thông tin và các hàm của audio component từ lệnh other.GetComponent<AudioSource>()
            // AudioSource audioSource = other.GetComponent<AudioSource>();

            // //play âm thanh từ component đó
            // audioSource.Play();

            Destroy(gameObject); // Hủy đối tượng này 
        }
    }
}
