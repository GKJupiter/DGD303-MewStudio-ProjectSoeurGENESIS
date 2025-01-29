using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;  // Mermi prefab'ı
    public Transform firePoint;      // Merminin ateş edileceği nokta
    public float fireRate = 2f;      // Ne kadar sürede bir ateş edilecek (saniye cinsinden)
    public float bulletSpeed = 5f;   // Merminin hızı
    private float nextFireTime = 0f; // Son ateşten sonra ne kadar zaman geçtiğini kontrol eder
    public Transform player;         // Oyuncu nesnesi

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate; // Bir sonraki ateşleme zamanını ayarla
        }
    }

    void Shoot()
    {
        if (player != null)
        {
            // Oyuncuya doğru yönelme
            Vector3 direction = player.position - firePoint.position;
            direction.z = 0;  // Z eksenindeki hareketi engellemek için
            direction.Normalize();  // Yönü normalize et

            // FirePoint'in yönünü oyuncuya çevir
            firePoint.up = direction; // FirePoint'i oyuncuya doğru çevir (dönmesini sağla)

            // Mermiyi yarat ve hareket ettir
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // FirePoint'in rotası ile mermi başlat
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = direction * bulletSpeed;  // Mermiyi oyuncuya doğru yönlendir
            }
        }
    }
}
