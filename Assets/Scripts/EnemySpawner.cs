using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Spawnlanacak düşman prefabı
    public Transform spawnPoint; // Düşmanın spawn olacağı yer
    public float spawnRate = 3f; // Kaç saniyede bir spawn olacak

    void Start()
    {
        // Belirli aralıklarla düşman spawn etmek için
        InvokeRepeating("SpawnEnemy", 2f, spawnRate);
    }

    void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}
