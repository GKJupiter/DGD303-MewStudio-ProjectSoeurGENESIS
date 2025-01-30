using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek oyuncu
    public Vector3 offset;   // Kamera ile oyuncu arasýndaki mesafe
    public float smoothSpeed = 0.125f; // Yumuþatma hýzý

    void LateUpdate()
    {
        if (target == null) return;

        // Hedef pozisyonunu hesapla
        Vector3 desiredPosition = target.position + offset;

        // Kamerayý yumuþak geçiþle hedef pozisyonuna taþý
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}
