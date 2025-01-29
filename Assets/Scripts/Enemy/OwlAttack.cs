using UnityEngine;

public class Owl : MonoBehaviour
{
    public GameObject trapPrefab;  // Tuzak prefab'ı
    public Transform spawnPoint;   // Tuzakların spawn olacağı nokta
    public float trapDelay = 2f;   // Tuzakların yerleştirilme süresi (saniye cinsinden)
    public int numberOfTraps = 3;  // Baykuşun yerleştireceği tuzak sayısı

    void Start()
    {
        InvokeRepeating("PlaceTrap", 0f, trapDelay);  // Belirli aralıklarla tuzak yerleştir
    }

    void PlaceTrap()
    {
        if (numberOfTraps > 0)
        {
            // Tuzak oluştur
            GameObject trap = Instantiate(trapPrefab, spawnPoint.position, Quaternion.identity);
            trap.GetComponent<OwlTrap>().ActivateTrap();  // Tuzak aktif hale gelir
        }
        else if (numberOfTraps == 3)
        {
            CancelInvoke("PlaceTrap");  // Tuzak yerleştirme işlemini durdur
        }
    }
}
