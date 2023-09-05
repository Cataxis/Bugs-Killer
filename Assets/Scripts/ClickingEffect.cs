using UnityEngine;
using DG.Tweening;

public class ClickingEffect : MonoBehaviour
{
    public Transform imageTransform; // Asigna el transform de la imagen en el Inspector
    public float clickDuration = 0.3f; // Duración de un "click"
    public int clickCount = 5; // Número de "clicks"

    private Vector3 originalScale;

    private void Start()
    {
        originalScale = imageTransform.localScale;
        StartClickingAnimation();
    }

    private void StartClickingAnimation()
    {
        Sequence clickSequence = DOTween.Sequence();

        for (int i = 0; i < clickCount; i++)
        {
            clickSequence.Append(imageTransform.DOScale(originalScale * 1.2f, clickDuration / 2));
            clickSequence.Append(imageTransform.DOScale(originalScale, clickDuration / 2));
        }

        clickSequence.SetLoops(-1); // Repetir infinitamente
    }
}
