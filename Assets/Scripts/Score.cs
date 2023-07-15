using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text finalScoreText;
    [SerializeField] TMP_Text bestScoreText;

    float score;
    float finalScore;
    float bestScore;

    bool isAnimating;

    private void Start()
    {
        bestScore = PlayerPrefs.GetFloat("BestScore", 0f);
        bestScoreText.text = "Besto: " + ((int)bestScore).ToString();
    }

    private void Update()
    {
        if (GameManager.Instance.IsPlayerAlive)
        {
            score += 1 * Time.deltaTime;
            scoreText.text = ((int)score).ToString();
        }
        else
        {
            if (score > finalScore && !isAnimating)
            {
                StartCoroutine(AnimateScore(finalScore, score));
                finalScore = score;
            }
        }
    }

    IEnumerator AnimateScore(float startValue, float endValue)
    {
        isAnimating = true;
        float currentValue = startValue;
        float duration = 1f; // Duraci�n de la animaci�n en segundos

        float timer = 0f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            currentValue = Mathf.Lerp(startValue, endValue, timer / duration);
            finalScoreText.text = "Score: " + ((int)currentValue).ToString();
            bestScoreText.text = "Besto: " + ((int)bestScore).ToString(); // Actualizar el texto de bestScore durante la animaci�n
            yield return null;
        }

        finalScoreText.text = "Score: " + ((int)endValue).ToString();

        if (endValue > bestScore)
        {
            bestScore = endValue;
            bestScoreText.text = "Besto: " + ((int)bestScore).ToString();
            PlayerPrefs.SetFloat("BestScore", bestScore);
        }

        isAnimating = false;
    }
}


