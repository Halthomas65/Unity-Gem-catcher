using UnityEngine;

public class EnemyPatrolSpawner : MonoBehaviour
{
    // Độ cao của vật được spawn
    public Transform posYSpawn;
    public GameObject pointA;
    public GameObject pointB;
    // Khai báo biến để chứa prefab của vật thể. Đây sẽ là đối tượng mà chúng ta sẽ tạo ra trong trò chơi.
    public GameObject enemyPrefab;
    
    // Biến đếm thời gian kể từ lần sinh vật thể cuối cùng.
    public float startTime = 2f; 
    [SerializeField] private float timer;
    // Khoảng thời gian (tính bằng giây) giữa mỗi lần sinh vật thể mới.
    public float spawnInterval = 3f; //tần suất spawn: 3 giây / 1 gem
    

    void Start()
    {
        timer = startTime; // Gán giá trị ban đầu cho biến timer
    }
    void Update()
    {
        if (TimeManager.isGameOver) // nếu trò chơi kết thúc
        {
            return; // thoát khỏi hàm Update
        }

        // Cộng dồn thời gian từ lần cuối cập nhật đến bây giờ vào biến timer.
        timer += Time.deltaTime;
        // Kiểm tra nếu thời gian đã đủ lớn bằng hoặc lớn hơn khoảng thời gian sinh vật thể.
        if (timer >= spawnInterval)
        {
            Spawn(); // Gọi hàm sinh vật thể.
            timer = 0; // Đặt lại biến đếm thời gian.
        }
    }

    public void Spawn() {
          float randomX = Random.Range(-8f, 8f); //Màn hình rộng 16 point nên lề trái là -8 và biên phải là 8
                                               //Khai báo một biến tọa độ vị trí và lưu giá trị tọa độ trên
        Vector3 spawnPosition = new Vector3(randomX, posYSpawn.position.y, 0); // Đưa biến số này vào Vector3, để tạo tọa độ vị trí mới

        var enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        var enemyPatrol = enemy.GetComponent<EnemyPatrol>();
        enemyPatrol.pointA = pointA;
        enemyPatrol.pointB = pointB;
        enemyPatrol.Setup();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}