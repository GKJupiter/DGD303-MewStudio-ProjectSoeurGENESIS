using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;   // Mermi prefabı
    public UnityEngine.Transform firePoint;       // Ateş etme noktası
    public float bulletSpeed = 10f;   // Mermi hızı
    public float destroyTime = 2f;    // Merminin silinme süresi
    public Camera mainCam;
    private Vector3 mousePos;
    public float _bulletForce;


    void Update()
    {

        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookDir = mousePos - transform.position;
        
        Fire();

    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1")) // Sol mouse tuşuna basıldığında
        {
            // Fare konumunu dünya koordinatlarına çevirme
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f; // 2D oyun olduğu için Z eksenini sıfırlıyoruz

            // Mermiyi oluşturma
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

            // Doğru yöne yönlendirme
            Vector2 shootingDirection = (mousePos - firePoint.position).normalized;

            // Rigidbody2D bileşeni alınıyor
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.linearVelocity = shootingDirection * _bulletForce; // Sabit hızla gönderme
            }

            // Mermiyi döndürerek doğru yöne bakmasını sağlama
            float angle = Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(0, 0, angle);


        }
    }
}
