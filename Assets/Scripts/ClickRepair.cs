using UnityEngine;

public class ClickRepair : MonoBehaviour
{
    public GameObject objectToSpawn;
    public int minTouchCount = 5;
    public int maxTouchCount = 10;

    private int touchCount = 0;
    private int requiredTouchCount;

    private bool inputRegistered = false; // Track if input has been registered

    private void Start()
    {
        requiredTouchCount = Random.Range(minTouchCount, maxTouchCount + 1);
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            RegisterInput();
        }

        if (inputRegistered)
        {
            touchCount++;

            if (touchCount >= requiredTouchCount)
            {
                Quaternion rotation = Quaternion.Euler(0f, 0f, 90f);
                GameObject spawnedObject = Instantiate(objectToSpawn, transform.position, rotation);
                spawnedObject.transform.rotation = rotation;
                Destroy(gameObject);
            }
        }
    }

    private void RegisterInput()
    {
        if (!inputRegistered)
        {
            inputRegistered = true;
        }
    }
}
