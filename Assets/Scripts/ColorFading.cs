using UnityEngine;

public class ColorFading : MonoBehaviour
{
    public float fadeDuration = 6f; // Duración del desvanecimiento en segundos

    private SpriteRenderer spriteRenderer;
    private float tiempoPasado = 0f;
    private Color colorInicial;
    private Color colorFinal;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        colorInicial = spriteRenderer.color;
        colorFinal = new Color(colorInicial.r, colorInicial.g, colorInicial.b, 0f);
    }

    void Update()
    {
        tiempoPasado += Time.deltaTime;

        if (tiempoPasado <= fadeDuration / 2)
        {
            float alfaActual = 1f - (tiempoPasado / (fadeDuration / 2));
            spriteRenderer.color = new Color(colorInicial.r, colorInicial.g, colorInicial.b, alfaActual);
        }
        else if (tiempoPasado > fadeDuration / 2 && tiempoPasado <= fadeDuration)
        {
            float alfaActual = (tiempoPasado - fadeDuration / 2) / (fadeDuration / 2);
            spriteRenderer.color = new Color(colorInicial.r, colorInicial.g, colorInicial.b, alfaActual);
        }
    }
}
