using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IPickup
{

    void OnPickup();
    void FindPlayer();

    void CalculateScore();
    
}
