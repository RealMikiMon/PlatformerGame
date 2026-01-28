using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloorContact : MonoBehaviour
{
    public static event Action<FloorContact> OnFloorContact;

    private void OnTriggerEnter2D(Collider2D Other)
    {
        OnFloorContact?.Invoke(this);
    }
}