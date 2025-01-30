using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEndTrigger : MonoBehaviour
{
    public float delayBeforeLoad = 2f; // Menüye gitmeden önce bekleme süresi
    public GameObject endMessageUI; // UI mesajını gösterecek obje

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Player objesiyle çarpıştı mı?
        {
            endMessageUI.SetActive(true); // UI mesajını göster
            Invoke("LoadMainMenu", delayBeforeLoad); // Belirli süre sonra sahneyi değiştir
        }
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // MainMenu sahnesine geçiş yap
    }
}
