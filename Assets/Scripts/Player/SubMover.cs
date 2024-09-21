using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SubMover : MonoBehaviour
{
    [Header("Class References")]
    public Transform subTransform;
    [SerializeField] private MouseController mouseController;
    [SerializeField] private MiningManager miningManager;
    [SerializeField] private Transform tracker;

    [Header("Movement Properties")]
    public float rotSpeed;
    public float movementSpeed;

    [Header("Stop Distance Properties")]
    public float stopDistance;
    public float indicatorStopDistance;
    public float resourceStopDistance;

    [Header("Player Angle Offset Properties")]
    [SerializeField] private float angleOffsetX;
    [SerializeField] private float angleOffsetZ;


    [Header("Dash Properties")]
    public float BaseDashMultiplier;
    public float ForcedDashMultiplier;
    public float HeatLevel = 0;
    public float HeatIncreaseRate = 0.1f;
    public bool Overheated = false;
    public Vector3 input;

    //Movement Props

    private enum DashType
    {
        DASH,
        FORCED_DASH
    }

    private DashType dashType;

    private const string horizontalInput = "Horizontal";
    private const string verticalInput = "Vertical";

    private Vector3 angleX;
    private Vector3 angleZ;

    private float horizontal;
    private float vertical;


    private void Update()
    {
        if (CheckInput() && SubStateManager.currentSubState != GameConstants.PlayerStates.FORCED_DASHING)
        {
           SubStateManager.currentSubState = GameConstants.PlayerStates.MOVING;
        }

        if (SubStateManager.currentSubState == GameConstants.PlayerStates.MINNING && miningManager.TargetNodeTransorm != null && !CanDash())
        {
            RotateSubTowards(miningManager.TargetNodeTransorm);
        }

    }

    private void FixedUpdate()
    {
        if (SubStateManager.currentSubState == GameConstants.PlayerStates.MOVING)
        {
            Move();
        }



        if(SubStateManager.currentSubState == GameConstants.PlayerStates.FORCED_DASHING)
        {
            ForcedMove();
        }

        if (!CanDash())
        {
            ReduceHeat();
        }

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(IEForcedDash());
        }
#endif
    }

    public void Move()
    {

        horizontal = Input.GetAxis(horizontalInput);
        vertical = Input.GetAxis(verticalInput);

        Vector3 position = transform.position;

        CalculateAngleOffset();
        input = (horizontal * angleX + vertical * angleZ).normalized;
        Vector3 movement = input * movementSpeed * Time.deltaTime;

        Vector3 newPos = position + movement;
        Vector3 targetPos = new Vector3(newPos.x, transform.position.y, newPos.z);

        if (!CanDash())
        {
            MovementHelpers.MoveObjectToward(transform, input, targetPos, movementSpeed, rotSpeed);
        }
        else
        {
            MovementHelpers.MoveObjectToward(transform, input, targetPos, movementSpeed, rotSpeed, BaseDashMultiplier);
            IncreaseHeat();
        }

    }

    public void ForcedMove()
    {

        horizontal = Input.GetAxis(horizontalInput);
        vertical = Input.GetAxis(verticalInput);

        Vector3 position = transform.position;

        CalculateAngleOffset();
        input = (horizontal * angleX + vertical * angleZ).normalized;
        Vector3 movement = input * movementSpeed * Time.deltaTime;

        Vector3 newPos = position + movement;
        Vector3 targetPos = new Vector3(newPos.x, transform.position.y, newPos.z);

        MovementHelpers.MoveObjectForward(transform, input, movementSpeed, rotSpeed,ForcedDashMultiplier);

    }

    private void CalculateAngleOffset()
    {
        //Normalize angle to have isometric view make sense
        angleZ.x = Mathf.Sin(angleOffsetZ);
        angleZ.z = Mathf.Cos(angleOffsetZ);
        angleZ.Normalize();

        angleX.x = Mathf.Sin(angleOffsetX);
        angleX.z = Mathf.Cos(angleOffsetX);
        angleX.Normalize();
    }
    public void RotateSubTowards(Transform target)
    {
        MovementHelpers.FocusOnObject(transform,target,rotSpeed);
    }

    public bool CheckInput()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("input registered");
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CanDash()
    {
        dashType = DashType.DASH;
        return Input.GetKey(KeyCode.Space) && HeatLevel < 105 && !Overheated;
    }

    public void IncreaseHeat()
    {
        if(HeatLevel < 100)
        {
            HeatLevel += HeatIncreaseRate;
            Debug.Log("Dashing");
        }
        else
        {
            StartCoroutine(OverHeat());
        }

    }

    public void ReduceHeat()
    {
        if(HeatLevel > 0)
        {
            HeatLevel -= HeatIncreaseRate;
        }
    }
    IEnumerator OverHeat()
    {
        HeatLevel = 120;
        Overheated = true;
        while(HeatLevel > 0)
        {
            yield return null;
        }
        Overheated = false;
    }

    public IEnumerator IEForcedDash()
    {
        SubStateManager.currentSubState = GameConstants.PlayerStates.FORCED_DASHING;
        yield return new WaitForSeconds(1);
        SubStateManager.currentSubState = GameConstants.PlayerStates.MOVING;
    }
}
