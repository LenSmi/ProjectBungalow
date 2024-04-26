using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MovementHelpers
{

    public static void MoveObjectToward(Transform p1, Vector3 input, Vector3 destination, float speed, float rotationSpeed)
    {
        p1.position = Vector3.MoveTowards(p1.position, destination, speed * Time.fixedDeltaTime);


        Quaternion previousRotation = new Quaternion();

        if (input != Vector3.zero) 
        {

            var relativePos = input;
            Debug.DrawRay(p1.position, relativePos * 2f, Color.green);
            //Get rotations

            var rotationPoint = Quaternion.LookRotation(relativePos);

            rotationPoint.x = 0;
            rotationPoint.z = 0;
            //Set rotation

            

            p1.rotation = Quaternion.Slerp(p1.rotation, rotationPoint, rotationSpeed * Time.deltaTime);
            previousRotation = p1.rotation;
        }
       


    }

    public static void MoveObjectToward(Transform p1, Transform p2, Vector3 destination, float speed, float rotationSpeed, float stopThreshold)
    {
        p1.position = Vector3.MoveTowards(p1.position, destination, speed * Time.fixedDeltaTime);

        //Rotate to
        if (Vector3.Distance(p1.position, destination) > stopThreshold)
        {
            Vector3 relativePosition = p2.position - p1.position;
            Quaternion targetRot = Quaternion.LookRotation(relativePosition, p1.up);
            targetRot.x = 0;
            targetRot.z = 0;
            p1.rotation = Quaternion.RotateTowards(p1.rotation, targetRot, rotationSpeed * Time.deltaTime);
        }
    }


}
