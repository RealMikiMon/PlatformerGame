using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int Score = 0;

    public static Action<int> OnScoreUpdated;

    private void OnEnable()
    {
        CoinCollection.OnCoinCollected += UpdateScore;
    }

    private void OnDisable()
    {
        CoinCollection.OnCoinCollected -= UpdateScore;
    }

    private void UpdateScore(CoinCollection Coin)
    {
        Score += Coin.Value;

        OnScoreUpdated?.Invoke(Score);
    }
}