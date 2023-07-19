using UnityEngine;

public class AlphaController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("El objeto no tiene un componente SpriteRenderer.");
        }
    }

    void Update()
    {
        Color currentColor = spriteRenderer.color;

        if (currentColor.a <= 0f)
        {
            Destroy(gameObject);
        }

        else
        {
            currentColor.a = Mathf.Lerp(currentColor.a, 0f, Time.deltaTime);
            spriteRenderer.color = currentColor;
        }
    }
}
