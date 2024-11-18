using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAidMover : MonoBehaviour
{
    public float speed = 5f;
    public float aidAmount = 5;    // Thời gian được cộng thêm cho nhân vật 

    void Update()
    {
        if (TimeManager.isGameOver)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.down * speed * Time.deltaTime); //tạo chuyển động theo phương thẳng đứng hướng xuống với tốc độ trên theo thời gian
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Điều kiện kiểm tra thông tin của OTHER - đối tượng va chạm với Gem
        if (other.gameObject.CompareTag("Player"))  // Va chạm với đối tượng Player
        {
            // Thêm thời gian cho trò chơi
            TimeManager.remainingTime += aidAmount;

            //Khai báo biến tên audioSource để gán thông tin và các hàm của audio component từ lệnh other.GetComponent<AudioSource>()
            AudioSource audioSource = other.GetComponent<AudioSource>();

            //play âm thanh từ component đó
            audioSource.Play();

            Destroy(gameObject); // Hủy đối tượng này - Gem
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
