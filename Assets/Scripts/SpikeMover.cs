using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMover : MonoBehaviour
{
  /*
  * Spike làm chậm và gây mất máu cho nhân vật
  */
  public float speed = 5f;
  public int slow = 2;    // Tốc độ giảm của nhân vật theo cấp số nhân

  void Update()
  {
    if (ScoreManager.isGameOver)
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
      // Giới hạn tốc độ bị giảm của nhân vật
      if (CharacterMovement.speed <= CharacterMovement.minSpeed)
      {
        CharacterMovement.speed /= slow;
      }

      //Khai báo biến tên audioSource để gán thông tin và các hàm của audio component từ lệnh other.GetComponent<AudioSource>()
      AudioSource audioSource = other.GetComponent<AudioSource>();

      //play âm thanh từ component đó
      audioSource.Play();

      Destroy(gameObject); // Hủy đối tượng này - Gem

      //   new WaitForSeconds(effectTime);
      //   CharacterMovement.speed /= boost; // booster hết tác dụng
    }
    else if (other.gameObject.CompareTag("Ground"))
    {
      Destroy(gameObject);
    }
  }
}
