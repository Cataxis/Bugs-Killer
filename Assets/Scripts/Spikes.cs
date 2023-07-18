using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] GameObject newObjectPrefab;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Instantiate(newObjectPrefab, collision.transform.position, Quaternion.identity);
            GameManager.Instance.BugDied();
        }

    }
}
