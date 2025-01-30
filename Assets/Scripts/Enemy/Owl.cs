using UnityEngine;

public class Owl : MonoBehaviour
{
    public GameObject trapPrefab;   // Tuzak prefab'ı
    public float trapDelay = 2f;    // Tuzakların yerleştirilme süresi (saniye cinsinden)
    public int numberOfTraps = 3;   // Baykuşun yerleştireceği tuzak sayısı
    public float spawnYOffset = -1f; // Oyuncunun altına yerleştirme mesafesi

    private GameObject player;      // Oyuncu objesi
    private Animator animator;      // Animator bağlantısı için

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");  // Oyuncuyu bul
        animator = GetComponent<Animator>();                    // Animator bileşenini al
        InvokeRepeating("PlaceTrap", 0f, trapDelay);           // Belirli aralıklarla tuzak yerleştir
    }

    void PlaceTrap()
    {
        if (numberOfTraps > 0 && player != null)
        {
            // Tuzakları yerleştirirken, oyuncunun altındaki pozisyonu hesapla
            Vector3 spawnPosition = player.transform.position + new Vector3(0, spawnYOffset, 0);

            // Tuzak oluştur
            GameObject trap = Instantiate(trapPrefab, spawnPosition, Quaternion.identity);
            trap.GetComponent<OwlTrap>().ActivateTrap(); // Tuzak aktif hale gelir

            // Animasyonu tetikle
            animator.SetTrigger("attackTriggerOwl");

            numberOfTraps--; // Tuzak sayısını azalt
        }
        else
        {
            CancelInvoke("PlaceTrap"); // Tuzak yerleştirme işlemini durdur
        }
    }
}
