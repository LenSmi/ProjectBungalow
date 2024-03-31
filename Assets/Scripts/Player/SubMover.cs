using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMover : MonoBehaviour
{
    public MouseController mouseController;
    public float rotSpeed;
    public float movementSpeed;
    public float distanceToStop;

    // Update is called once per frame
    void FixedUpdate()
    {
            Move();
    }

    public void Move()
    {
        // Move to position
        Vector3 targetPos = new Vector3(mouseController.raycastHit.point.x, transform.position.y, mouseController.raycastHit.point.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, movementSpeed * Time.fixedDeltaTime);

        //Rotate to

        if (Vector3.Distance(transform.position, mouseController.raycastHit.point) > distanceToStop)
        {
            Vector3 relativePosition = mouseController.raycastHit.point - transform.position;
            Quaternion targerRot = Quaternion.LookRotation(relativePosition, transform.up);
            targerRot.x = 0;
            targerRot.z = 0;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targerRot, rotSpeed * Time.fixedDeltaTime);
        }
       
    }
}
