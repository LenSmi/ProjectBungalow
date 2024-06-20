using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAttackEndState : GameState, IGameState
{
    public override void Awake()
    {
        base.Awake();
    }

    public void EnterGamestate()
    {
        //gameManager.UIManager().scoreCalc.SetActive(true);
        GameManager.Instance().UIManager().scoreCalc.SetActive(true);
    }

    public void ExitGamestate()
    {

    }

}
