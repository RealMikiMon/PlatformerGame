using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    private void OnEnable()
    {
        FloorContact.OnFloorContact += PlayerDeath;
    }

    private void OnDisable()
    {
        FloorContact.OnFloorContact -= PlayerDeath;
    }

    private void PlayerDeath(FloorContact contact)
    {
        SceneHandler.instance.ReloadScene();
    }
}