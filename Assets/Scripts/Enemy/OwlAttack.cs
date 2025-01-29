using UnityEngine;

public class Owl : MonoBehaviour
{
    public GameObject trapPrefab;  // Tuzak prefab'ı
    public float trapDelay = 2f;   // Tuzak bırakma süresi
    public int numberOfTraps = 3;  // Kaç tuzak bırakacak
    private Transform player;      // Player'ın transform'u

    void Start()
    {
        // Oyuncuyu sahnede bul
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
            InvokeRepeating("PlaceTrap", 0f, trapDelay);  // Belirli aralıklarla tuzak bırak
        }
        else
        {
            Debug.LogWarning("Player bulunamadı! Baykuş tuzak bırakmayacak.");
        }
    }

    void PlaceTrap()
    {
        if (player == null || numberOfTraps <= 0) return;

        // Tuzak oluştur ve Player'ın altına bırak
        Vector3 trapPosition = new Vector3(player.position.x, player.position.y - 1f, player.position.z);
        if (numberOfTraps > 0)
        {  
            GameObject trap = Instantiate(trapPrefab, trapPosition, Quaternion.identity);
            trap.GetComponent<OwlTrap>().ActivateTrap(); 
        }
        else if (numberOfTraps == 3)
        {
            CancelInvoke("PlaceTrap");  // Tuzak yerleştirme işlemini durdur
        }
    }
}
