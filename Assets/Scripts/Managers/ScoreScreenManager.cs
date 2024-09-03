using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScreenManager : MonoBehaviour
{
    public void LoadSaloon()
    {
        GameManager.Instance().WorldStateManager().TransitionToState(EGameStates.ScoreAttackSaloon);
    }
}
