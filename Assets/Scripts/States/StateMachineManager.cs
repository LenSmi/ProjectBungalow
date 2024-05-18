using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TransitionToState(new TrenchState());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TransitionToState(IGameState gameState)
    {

    }
}
