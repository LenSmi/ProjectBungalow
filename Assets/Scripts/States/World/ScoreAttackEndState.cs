using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAttackEndState : GameState
{
    public override void Awake()
    {
        base.Awake();
    }

    public override void EnterGamestate()
    {
        //gameManager.UIManager().scoreCalc.SetActive(true);
        GameManager.Instance().UIManager().scoreCalc.SetActive(true);
    }

    public override void ExitGamestate()
    {

    }

}
