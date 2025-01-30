using UnityEngine;

public class NPCShooter : MonoBehaviour
{
    public GameObject bulletPrefab;  // Mermi prefab'i
    public Transform firePoint;      // Ate� noktas�
    public float fireRate = 1.5f;    // Ate� etme h�z�
    public float bulletSpeed = 4f;   // Mermi h�z�
    public float shootAngleRange = 20f; // Ate� a��s� aral���
    private float nextFireTime = 0f; // Son ate� zaman�

    public Animator npcAnimator; // NPC animasyonlar� i�in

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // **Attack animasyonunu tetikle**
        npcAnimator.SetTrigger("attackTrigger");

        // NPC'nin ate� etti�i y�n
        Vector3 forwardDirection = transform.localScale.x < 0 ? transform.right : -transform.right;

        // Rastgele bir a�� se�
        float randomAngle = Random.Range(-shootAngleRange, shootAngleRange);

        // Yeni y�n olu�tur
        Quaternion rotation = Quaternion.Euler(0, 0, randomAngle);
        Vector3 direction = rotation * forwardDirection;

        // Mermi olu�tur ve h�z ver
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * bulletSpeed;
        }
    }
}
