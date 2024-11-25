using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
  /*
  * Spike làm chậm và gây mất máu cho nhân vật
  */
  public int slow = 2;    // Tốc độ giảm của nhân vật theo cấp số nhân

  //Khai báo biến tên audioSource để gán thông tin và các hàm của audio component từ lệnh other.GetComponent<AudioSource>()
  public AudioClip spikeSound;
  public float volume = 2f;

  Animator animator;
  new Collider2D collider;

  public float spawnTime = 1.5f;

  void Start()
  {
    StartCoroutine(Spawn());
  }

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
      // Giới hạn tốc độ bị giảm của nhân vật
      if (CharacterMovement.speed >= CharacterMovement.minSpeed)
      {
        CharacterMovement.speed /= slow;
        Debug.Log("Current Speed: " + CharacterMovement.speed);
      }

      other.GetComponent<CharacterMovement>().audioSourceMainCharacter.PlayOneShot(spikeSound);
      Destroy(gameObject);
    }
  }

  IEnumerator Spawn()
  {
    animator = GetComponent<Animator>();
    animator.SetBool("justSpawn", true);
    collider = GetComponent<Collider2D>();
    collider.enabled = false;

    // Không cho nhân vật vào đối tượng này
    yield return new WaitForSeconds(spawnTime);

    // Mở lại nhân vật vào đối tượng này
    animator.SetBool("justSpawn", false);
    collider.enabled = true;
  }
}
