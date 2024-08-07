using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform cameraTransform; // The camera's transform
    public float shakeDuration = 0.5f; // Duration of the shake
    public float shakeAmount = 0.7f; // Amplitude of the shake
    public float decreaseFactor = 1.0f; // How quickly the shake decreases

    private Vector3 originalPos;
    private float currentShakeDuration = 0f;

    void Awake()
    {
        if (cameraTransform == null)
        {
            cameraTransform = GetComponent<Transform>();
        }
    }

    void OnEnable()
    {
        originalPos = cameraTransform.localPosition;
    }

    void Update()
    {
        if (currentShakeDuration > 0)
        {
            cameraTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
            currentShakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            currentShakeDuration = 0f;
            cameraTransform.localPosition = originalPos;
        }
    }

    // Method to call to start the camera shake
    public void ShakeCamera()
    {
        currentShakeDuration = shakeDuration;
    }

    // POLYMORPHISM
    public void ShakeCamera(float shakeDur)
    {
        currentShakeDuration = shakeDur;
    }
}
