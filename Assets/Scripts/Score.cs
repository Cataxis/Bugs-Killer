using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text finalScoreText;
    [SerializeField] TMP_Text bestScoreText;

    private int score;
    private int finalScore;
    private int bestScore;
    private bool isAnimating = false;

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreText.text = "Best: " + bestScore.ToString();
    }

    public void UpdateScore()
    {
        score = GameManager.Instance.Score;

        if (score > finalScore && !isAnimating)
        {
            StartCoroutine(AnimateScore(finalScore, score));
            finalScore = score;
        }

        scoreText.text = "Score: " + score.ToString();
    }

    IEnumerator AnimateScore(int startValue, int endValue)
    {
        isAnimating = true;
        float currentValue = startValue;
        float duration = 1f;

        float timer = 0f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            currentValue = Mathf.Lerp(startValue, endValue, timer / duration);
            finalScoreText.text = "Score: " + Mathf.RoundToInt(currentValue).ToString();
            yield return null;
        }

        finalScoreText.text = "Score: " + endValue.ToString();

        if (endValue > bestScore)
        {
            bestScore = endValue;
            bestScoreText.text = "Best: " + bestScore.ToString();
            PlayerPrefs.SetInt("BestScore", bestScore);
        }

        isAnimating = false;
    }
}

