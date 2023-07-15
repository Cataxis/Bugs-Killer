using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float shakeMagnitude;
    [SerializeField] private float shakeDuration;
    [SerializeField] private Transform cameraTransform;

    [SerializeField] GameObject newObjectPrefab;
    [SerializeField] private float speed;

    private float destroyDelay = 2f;
    private Rigidbody2D projectileRb;

    private void Awake()
    {
        projectileRb = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction)
    {
        projectileRb.velocity = direction * speed;
        Destroy(gameObject, destroyDelay);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            ShakeCamera();
            Instantiate(newObjectPrefab, collision.transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    private void ShakeCamera()
    {
        StartCoroutine(ShakeCameraCoroutine());
    }

    private IEnumerator ShakeCameraCoroutine()
    {
        Vector3 originalPosition = cameraTransform.position;
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float x = originalPosition.x + UnityEngine.Random.Range(-shakeMagnitude, shakeMagnitude);
            float y = originalPosition.y + UnityEngine.Random.Range(-shakeMagnitude, shakeMagnitude);
            cameraTransform.position = new Vector3(x, y, originalPosition.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        cameraTransform.position = originalPosition;
    }
}
