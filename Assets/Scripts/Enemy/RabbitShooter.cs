using UnityEngine;

public class RabbitShooter : MonoBehaviour
{
    public GameObject bulletPrefab;  // Mermi prefab'ı
    public Transform firePoint;      // Merminin ateş edileceği nokta
    public float fireRate = 2f;      // Ne kadar sürede bir ateş edilecek (saniye cinsinden)
    public float bulletSpeed = 5f;   // Merminin hızı
    private float nextFireTime = 0f; // Son ateşten sonra ne kadar zaman geçtiğini kontrol eder
    public float shootAngleRange = 30f; // 2*shootAngleRange derecenin yarısı (sağ ve sol yönler için)

    public Animator npcAnimator;  // Animasyon bağlantısı için

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            ShootRandomly();
            nextFireTime = Time.time + fireRate; // Bir sonraki ateşleme zamanını ayarla
        }
    }

    void ShootRandomly()
    {
        // **Attack animasyonunu tetikle**
        npcAnimator.SetTrigger("attackTrigger");

        // Tavşanın baktığı yönü al (sağa veya sola bakabilir)
        Vector3 forwardDirection = transform.localScale.x < 0 ? transform.right : -transform.right;

        // Rastgele bir açı seç
        float randomAngle = Random.Range(-shootAngleRange, shootAngleRange); // -shootAngle ile +shootAngle arası bir açı

        // Yeni yön oluşturmak için tavşanın baktığı yönün etrafında döndürme
        Quaternion rotation = Quaternion.Euler(0, 0, randomAngle); // Yalnızca Z ekseninde döndürme
        Vector3 direction = rotation * forwardDirection; // Yönü döndür

        // Mermiyi yarat ve hareket ettir
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * bulletSpeed; // Mermiyi rastgele yönlendirilmiş şekilde hareket ettir
        }
    }
}

