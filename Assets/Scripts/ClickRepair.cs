using UnityEngine;

public class ClickRepair : MonoBehaviour
{
    public GameObject objectToSpawn;
    public int minSpacePresses = 5;
    public int maxSpacePresses = 10;

    private int spacePresses = 0;
    private int requiredSpacePresses;

    private void Start()
    {
        requiredSpacePresses = Random.Range(minSpacePresses, maxSpacePresses + 1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetMouseButtonDown(1))
        {
            spacePresses++;

            if (spacePresses >= requiredSpacePresses)
            {
                Quaternion rotation = Quaternion.Euler(0f, 0f, 90f);
                GameObject spawnedObject = Instantiate(objectToSpawn, transform.position, rotation);
                spawnedObject.transform.rotation = rotation;
                Destroy(gameObject);
            }
        }
    }
}