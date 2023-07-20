using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour, IMover
{
    public MouseController _mouseController;
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
     
        
      Move();

       
    }

    public void Move()
    {
        // Move to position
        Vector3 targetPos = new Vector3(_mouseController.raycastHit.point.x, transform.position.y, _mouseController.raycastHit.point.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, movementSpeed * Time.fixedDeltaTime);

        //Rotate to
        if (Vector3.Distance(transform.position, _mouseController.raycastHit.point) > _distanceToStop)
        {
            Vector3 relativePosition = _mouseController.raycastHit.point - transform.position;
            Quaternion targerRot = Quaternion.LookRotation(relativePosition, transform.up);
            targerRot.x = 0;
            targerRot.z = 0;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targerRot, rotSpeed * Time.fixedDeltaTime);
        }
    }
}
