using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public MouseController _mouseController;
    public Transform playerTransform;
    public float _distanceToStop;
    public float rotSpeed;
    public float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        if (_mouseController == null) { Debug.LogWarning("No Main Camera found", gameObject); }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(SubStateManager.currentSubState == GameConstants.PlayerStates.MOVING)
        {
         
        }

    }
}
