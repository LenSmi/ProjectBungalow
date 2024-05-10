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

    private const string horizontalInput = "Horizontal";
    private const string verticalInput = "Vertical";

    private Vector3 angleX;
    private Vector3 angleZ;

    public float angleOffsetX;
    public float angleOffsetZ;

    private float horizontal;
    private float vertical;

    public Vector3 input;

    // Start is called before the first frame update
    void Start()
    {
        if (_mouseController == null) { Debug.LogWarning("No Main Camera found", gameObject); }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {

        horizontal = Input.GetAxis(horizontalInput);
        vertical = Input.GetAxis(verticalInput);

        //Current Position
        Vector3 position = transform.position;

        //Input and movement Vector
        CalculateAngleOffset();
        input = (horizontal * angleX + vertical * angleZ).normalized;
        Vector3 movement = input * movementSpeed * Time.deltaTime;

        //Desired Position
        Vector3 newPos = position + movement;
        Vector3 targetPos = new Vector3(newPos.x, transform.position.y, newPos.z);

        MovementHelpers.MoveObjectToward(transform, input, targetPos, movementSpeed, rotSpeed);

    }

    private void CalculateAngleOffset()
    {
        //Normalize angle to have isometric view make sense
        angleZ.x = Mathf.Sin(angleOffsetZ);
        angleZ.z = Mathf.Cos(angleOffsetZ);
        angleZ.Normalize();

        angleX.x = Mathf.Sin(angleOffsetX);
        angleX.z = Mathf.Cos(angleOffsetX);

    }

}
