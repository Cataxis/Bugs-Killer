using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float minDestructionTime = 5f;
    public float maxDestructionTime = 10f;

    private float destructionTime;

    private void Start()
    {
        destructionTime = Random.Range(minDestructionTime, maxDestructionTime);
        Invoke("DestroyPlayer", destructionTime);
    }

    private void DestroyPlayer()
    {
        Instantiate(objectToSpawn, objectToSpawn.transform.position, objectToSpawn.transform.rotation);
        Destroy(gameObject);
    }
}
