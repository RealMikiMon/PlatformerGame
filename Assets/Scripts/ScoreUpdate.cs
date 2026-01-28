using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int Score = 0;

    //public delegate void OnScoredDelegate(int score);
    //public static event OnScoredDelegate OnScored;

    public static Action<int> OnScoreUpdated;

    private void OnEnable()
    {
        CoinCollection.OnCoinCollected += UpdateScore;
    }

    private void OnDisable()
    {
        CoinCollection.OnCoinCollected -= UpdateScore;
    }

    private void UpdateScore(CoinCollection coin)
    {
        Score += coin.Value;

        OnScoreUpdated?.Invoke(Score);
    }
}