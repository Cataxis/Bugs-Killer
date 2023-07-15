using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    public Transform player;
    public float speed = 5f;
    public float shakeMagnitude = 0.1f;
    public float shakeDuration = 0.1f;

    private void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            direction.Normalize();
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            ShakeCamera();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            ShakeCamera();
            Destroy(collision.gameObject);
            Instantiate(explosion, collision.transform.position, Quaternion.identity);
            GameManager.Instance.IsPlayerAlive = false;
        }
    }

    private void ShakeCamera()
    {
        StartCoroutine(ShakeCameraCoroutine());
    }

    private IEnumerator ShakeCameraCoroutine()
    {
        Vector3 originalPosition = Camera.main.transform.position;
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float x = originalPosition.x + UnityEngine.Random.Range(-shakeMagnitude, shakeMagnitude);
            float y = originalPosition.y + UnityEngine.Random.Range(-shakeMagnitude, shakeMagnitude);
            Camera.main.transform.position = new Vector3(x, y, originalPosition.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        Camera.main.transform.position = originalPosition;
    }
}
