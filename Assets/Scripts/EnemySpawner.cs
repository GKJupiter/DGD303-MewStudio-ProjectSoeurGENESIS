using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Spawnlanacak düşman prefabı
    public Transform spawnPoint;    // Düşmanın doğacağı nokta
    public int maxEnemies = 3;      // Spawn edilecek maksimum düşman sayısı
    public float spawnRate = 3f;    // Spawn aralığı
    private int enemiesSpawned = 0; // Şu ana kadar spawn edilen düşman sayısı
    public bool canSpawn = true;    // Spawn olup olmayacağını kontrol eder

    void OnTriggerEnter2D(Collider2D other)
    {
        // Sadece "Player" tag'ine sahip nesne girdiğinde çalışsın
        if (other.CompareTag("Player") && canSpawn)
        {
            StartCoroutine(SpawnEnemy());  // Spawn işlemini başlat
            canSpawn = false;  // Tekrar tetiklenmemesi için devre dışı bırak
        }
    }

    System.Collections.IEnumerator SpawnEnemy()
    {
        // Şu anki spawn edilen düşman sayısı, maksimum sayıya ulaşmadıysa spawn etmeye devam et
        while (enemiesSpawned < maxEnemies)
        {
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);  // Düşmanı spawn et
            enemiesSpawned++;  // Spawn edilen düşman sayısını arttır

            yield return new WaitForSeconds(spawnRate);  // Spawn aralığı kadar bekle
        }

        // Maksimum sayıya ulaşıldığında spawn işlemi durur
        canSpawn = false;
        Debug.Log("Maksimum düşman sayısına ulaşıldı. Düşman spawn edilmesi durduruldu.");
    }
}
