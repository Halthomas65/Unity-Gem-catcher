using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterMover : MonoBehaviour
{
  /*
  * khai báo biến tốc độ là một số thực có giá trị bằng 5.
  * Public sẽ cho phép ta truy cập giá trị speed từ UnityEditor
  */
  public float speed = 5f;
  public int boost = 2;    // Tốc độ tăng lên của nhân vật theo cấp số nhân

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
      // Giới hạn tốc độ tăng lên của nhân vật
      if (CharacterMovement.speed <= CharacterMovement.maxSpeed)
      {
        CharacterMovement.speed *= boost;
        Debug.Log("Current Speed: " + CharacterMovement.speed);
      }

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
