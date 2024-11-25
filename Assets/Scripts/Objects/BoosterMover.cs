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
  public AudioClip boosterSound; // Assign the sound clip in the Unity editor
  public float volume = 2f;

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
    // Điều kiện kiểm tra thông tin của OTHER - đối tượng va chạm với Booster
    if (other.gameObject.CompareTag("Player"))  // Va chạm với đối tượng Player
    {
      // Giới hạn tốc độ tăng lên của nhân vật
      if (CharacterMovement.speed <= CharacterMovement.maxSpeed)
      {
        CharacterMovement.speed *= boost;
        Debug.Log("Current Speed: " + CharacterMovement.speed);
      }

      AudioSource.PlayClipAtPoint(boosterSound, transform.position, volume); // Play the sound at the position of the booster
      other.GetComponent<CharacterMovement>().audioSourceMainCharacter.PlayOneShot(boosterSound);

      Destroy(gameObject);
    }
    else if (other.gameObject.CompareTag("Ground"))
    {
      Destroy(gameObject);
    }
  }
}
