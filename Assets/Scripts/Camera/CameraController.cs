using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTarget;
    [SerializeField]
    private Vector3 _offset;
    [SerializeField]
    private float _lerpTime;
    [SerializeField]
    private float _forwardOffset;
    private void FixedUpdate()
    {
        LerpCamera();
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
}
