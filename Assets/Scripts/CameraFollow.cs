using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek oyuncu
    public Vector3 offset;   // Kamera ile oyuncu aras�ndaki mesafe
    public float smoothSpeed = 0.125f; // Yumu�atma h�z�

    void LateUpdate()
    {
        if (target == null) return;

        // Hedef pozisyonunu hesapla
        Vector3 desiredPosition = target.position + offset;

        // Kameray� yumu�ak ge�i�le hedef pozisyonuna ta��
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}
