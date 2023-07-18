using UnityEngine;

public class RalentizarTiempo : MonoBehaviour
{
    public float duracionRalentizacion = 2f; // Duración en segundos de la ralentización
    public float tiempoRalentizado = 0.5f; // Valor del TimeScale cuando está ralentizado

    private bool ralentizado = false;

    private void Start()
    {
        ralentizado = true;
        StartCoroutine(RalentizarPorUnTiempo(duracionRalentizacion));
    }


    private System.Collections.IEnumerator RalentizarPorUnTiempo(float duracion)
    {
        Time.timeScale = tiempoRalentizado;

        yield return new WaitForSecondsRealtime(duracion);

        Time.timeScale = 1f;
        ralentizado = false;
    }
}
