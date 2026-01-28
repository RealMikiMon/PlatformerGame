using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinCollection : MonoBehaviour
{
    public int Value = 5;

    public static Action<CoinCollection> OnCoinCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        OnCoinCollected?.Invoke(this);

        AudioManager.instance.PlaySound("Coin");
        if (Value == 150)
        {
            SceneHandler.instance.ChangeScene();
        }
        Destroy(gameObject);
    }
}