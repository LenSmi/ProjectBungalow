using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _playerTarget;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _lerpTime;
    [SerializeField] private float _forwardOffset;

    [Header("Orbit Camera Settings")]
    public bool IsOrbiting = false;
    public FloatReference distanceFromPlayer;
    private float _originalDistanceFromPlayerValue;
    [SerializeField] private float maxPitchAngle = 80f;
    [SerializeField] private float minPitchAngle = -10f;
    public float rotationSpeed;
    private float pitch;
    private float yaw;

    private void Start()
    {

        if (!distanceFromPlayer.UseConstant)
        {
            _originalDistanceFromPlayerValue = distanceFromPlayer.Value;
        }
        else
        {
            _originalDistanceFromPlayerValue = distanceFromPlayer.ConstantValue;
        }
    }

    private void FixedUpdate()
    {
       
        if (IsOrbiting)
        {
            RotateCameraAroundPlayer();
        }
        else
        {
            LerpCamera();
        }

    }

    void LerpCamera()
    {

        Vector3 currentPos = transform.position;
        Vector3 wantedPos = _playerTarget.position;
        wantedPos.y += _offset.y;
        wantedPos.x += _offset.x;
        wantedPos.z += _offset.z;
        wantedPos += _playerTarget.right * _forwardOffset;
        transform.position = Vector3.Lerp(currentPos, wantedPos, _lerpTime * Time.deltaTime);

    }
    void RotateCameraAroundPlayer()
    {
        // Get mouse input for yaw (horizontal rotation) and pitch (vertical rotation)
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        // Update yaw and pitch based on mouse input
        yaw += mouseX;
        pitch -= mouseY;

        // Clamp the pitch angle to prevent the camera from flipping over
        pitch = Mathf.Clamp(pitch, minPitchAngle, maxPitchAngle);

        // Create a rotation from the yaw and pitch values
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        // Calculate the new camera position based on the rotation and the desired distance from the player
        Vector3 direction = rotation * new Vector3(0, 0, -distanceFromPlayer.Value);

        // Update the camera's position relative to the player
        transform.position = _playerTarget.position + direction;

        // Make the camera look at the player's position
        transform.LookAt(_playerTarget.position);
    }

    private void OnDisable()
    {
        if (!distanceFromPlayer.UseConstant)
        {
            distanceFromPlayer.Value = _originalDistanceFromPlayerValue;
        }
        else
        {
            distanceFromPlayer.ConstantValue = _originalDistanceFromPlayerValue;
        }

    }
}
