using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerUp : MonoBehaviour
{
      public static Action<PowerUp> OnPowerUpCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        OnPowerUpCollected?.Invoke(this);

        Destroy(gameObject);
    }
   
   
}


