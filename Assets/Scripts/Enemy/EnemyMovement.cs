using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;  // Oyuncu nesnesi
    public float moveSpeed = 3f;  // Düşmanın hareket hızı

     void Start()
    {
        // Oyuncuyu sahnede bul
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("Player sahnede bulunamadı!"); 
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Oyuncuya doğru yönelme
            Vector3 direction = player.position - transform.position;
            direction.z = 0;  // Z ekseninde hareketi engellemek için
            direction.Normalize();  // Yönü normalize et

            // Düşman objesini hareket ettir
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            // Düşman objesini sadece yatayda (sağa/sola) döndür
            if (direction.x > 0) // Oyuncu sağda
            {
                transform.localScale = new Vector3(1, 1, 1);  // Sağ tarafa bakacak şekilde
            }
            else if (direction.x < 0) // Oyuncu solda
            {
                transform.localScale = new Vector3(-1, 1, 1);  // Sola bakacak şekilde
            }
        }
    }
}
