using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private IntValue _scoreData;

    private void Start()
    {
        scoreText.text = _scoreData.Score.ToString();
    }


    private void OnEnable()
    {
        BulletController.BulletCollision += IncreaseScore;
    }
    private void OnDisable()
    {
        BulletController.BulletCollision -= IncreaseScore;
    }

    private void IncreaseScore(Transform tr)
    {
        _scoreData.Score++;
        scoreText.text = _scoreData.Score.ToString();
    }
}