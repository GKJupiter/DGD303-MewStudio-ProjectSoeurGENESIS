using UnityEngine;

public class OwlTrap : MonoBehaviour
{
    public float trapDuration = 5f; // Tuzak ne kadar süre sonra yok olacak (saniye)
    private float timeElapsed = 0f; // Geçen zaman

    public float damageAmount = 10f;   // Tuzak hasar miktarı
    public int damageTimes = 3;        // Hasar verme sayısı
    private int damageCount = 0;       // Gerçekleşen hasar sayısı
    public float damageInterval = 1f;  // Hasar verme aralığı (saniye cinsinden)
    private float nextDamageTime = 0f; // Sonraki hasar zamanı

    private bool isActive = false;     // Tuzak aktif mi?

    // Tuzağı aktive etme fonksiyonu
    public void ActivateTrap()
    {
        isActive = true;  // Tuzak aktif hale gelir
        timeElapsed = 0f; // Zamanı sıfırla
        damageCount = 0;  // Hasar sayısını sıfırla
    }

    void Update()
    {
        if (isActive)
        {
            // Geçen zamanı güncelle
            timeElapsed += Time.deltaTime;

            // Eğer süre dolmuşsa, tuzağı yok et
            if (timeElapsed >= trapDuration)
            {
                Destroy(gameObject); // Tuzağı yok et
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // Eğer oyuncu tuzağa girerse ve tuzak aktifse
        if (other.CompareTag("Player") && isActive)
        {
            // Belirli bir süre aralıkla hasar ver
            if (Time.time >= nextDamageTime)
            {
                other.GetComponent<Health>().TakeDamage(damageAmount);
                damageCount++;
                nextDamageTime = Time.time + damageInterval; // Sonraki hasar zamanı

                // Hasar sayısı tamamlandığında tuzağı yok et
                if (damageCount >= damageTimes)
                {
                    Destroy(gameObject); // Hasar sayısı tamamlandığında tuzağı yok et
                }
            }
        }
    }
}
