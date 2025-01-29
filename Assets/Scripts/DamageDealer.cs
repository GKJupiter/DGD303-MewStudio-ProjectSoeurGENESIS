using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float damageAmount = 10f; // Hasar miktarı

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Çarpışılan objede Health bileşeni varsa hasar uygula
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damageAmount);

            // Düşmanın velocity'sini sıfırla (isteğe bağlı)
            Rigidbody2D enemyRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (enemyRb != null)
            {
                enemyRb.linearVelocity = Vector2.zero;
            }
        }

        // Mermiyi yok et
        Destroy(gameObject);
    }
}
