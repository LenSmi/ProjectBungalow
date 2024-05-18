using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerMover : MonoBehaviour, IMover
{
    public Transform _toFollowTransform;
    public float _targetDistance;
    public float _allowedDistance;
    public float _speed;
    public float _rotSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        //TODO: Implement warp if pal gets lost.
        Move(_toFollowTransform.position);
    }


    public void Move(Vector3 point)
    {
        Vector3 newPos = point - (_toFollowTransform.forward * _allowedDistance) + (_toFollowTransform.up * _targetDistance);
        Vector3 targetPos = new Vector3(newPos.x, transform.position.y, newPos.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, _speed * Time.fixedDeltaTime);
       

        Vector3 relativePosition = _toFollowTransform.position - transform.position;
        Quaternion targerRot = Quaternion.LookRotation(relativePosition, transform.up);
        targerRot.x = 0;
        targerRot.z = 0;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targerRot, _rotSpeed * Time.fixedDeltaTime);   
        
    }
}
