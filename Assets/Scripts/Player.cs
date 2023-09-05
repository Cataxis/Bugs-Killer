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

    private void Update()
    {
        CheckTouchInput();
    }

    private void CheckTouchInput()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            Ray ray = Camera.main.ScreenPointToRay(touchPosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    DestroyPlayer();
                }
            }
        }
    }

    private void DestroyPlayer()
    {
        Instantiate(objectToSpawn, objectToSpawn.transform.position, objectToSpawn.transform.rotation);
        Destroy(gameObject);
    }
}
