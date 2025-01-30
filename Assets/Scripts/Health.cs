using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;    // Maksimum sağlık
    private float currentHealth;      // Mevcut sağlık
    public GameObject deathEffect;    // Ölüm efekti (isteğe bağlı)

    public bool isPlayer;  // Eğer bu true ise, Player için çalışacak, değilse Enemy için çalışacak

    void Start()
    {
        // Sağlığı maksimum değere ayarla
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        // Sağlığı azalt
        currentHealth -= damageAmount;

        // Sağlık sıfıra ulaştığında öl
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float healAmount)
    {
        // Sağlığı artır (maksimum sağlık sınırını aşmamalı)
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void Die()
    {
        // Ölüm efekti oluştur
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        if (isPlayer)
        {
            PlayerDied();
        }
        else
        {
            EnemyDied();
        }
    }

    private void PlayerDied()
    {
        LevelManager.instance.GameOver(); // Oyunu bitir
    }

    private void EnemyDied()
    {
        Destroy(gameObject); // Düşmanı yok et
    }

    public float GetHealthPercentage()
    {
        // Sağlık yüzdesini döndür
        return currentHealth / maxHealth;
    }
}
