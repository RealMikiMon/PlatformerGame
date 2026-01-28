using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinCollection : MonoBehaviour
{
    public int Value = 5;

    public static Action<CoinCollection> OnCoinCollected;

    private void OnTriggerEnter2D(Collider2D Other)
    {
        OnCoinCollected?.Invoke(this);
        AudioManager.Instance.PlaySound("Coin");
        if (Value == 150)
        {
            SceneHandler.Instance.ChangeScene();
        }
        Destroy(gameObject);
    }
}