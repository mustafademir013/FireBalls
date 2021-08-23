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
        scoreText.text = _scoreData.Value.ToString();
    }
    private void OnEnable()
    {
        Bullet.BulletCollision += IncreaseScore;
    }
    private void OnDisable()
    {
        Bullet.BulletCollision -= IncreaseScore;
    }

    private void IncreaseScore(Transform tr)
    {
        _scoreData.Value++;
        scoreText.text = _scoreData.Value.ToString();
    }
}
