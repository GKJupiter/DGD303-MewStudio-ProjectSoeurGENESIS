using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;   // Mermi prefabı
    public Transform firePoint;      // Ateş etme noktası
    public float bulletSpeed = 10f;  // Mermi hızı
    public float destroyTime = 2f;   //Merminin silinme süresi

    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1")) // Ateş tuşuna basıldığında
        {
// Karakterin bakış yönüne göre mermiyi fırlatıyoruz
    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    bullet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(bulletSpeed * transform.localScale.x, 0f);

            // Mermiyi belirli bir süre sonra yok et (optimizasyon için)
            Destroy(bullet, destroyTime);
        }
    }
}