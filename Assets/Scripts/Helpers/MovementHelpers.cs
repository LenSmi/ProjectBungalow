using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public static class MovementHelpers
{

    public static void MoveObjectToward(Transform p1, Vector3 input, Vector3 destination, float speed, float rotationSpeed, float speedMultiplier = 1)
    {
        var speedM = speed * speedMultiplier;
        var stepSpeed = speedM * Time.fixedDeltaTime;
        //p1.position = Vector3.MoveTowards(p1.position, destination, stepSpeed);
        p1.position = Vector3.Lerp(p1.position,destination, stepSpeed);

        Quaternion previousRotation = new Quaternion();

        if (input != Vector3.zero) 
        {

            var relativePos = input;
            Debug.DrawRay(p1.position, relativePos * 2f, Color.green);

            var rotationPoint = Quaternion.LookRotation(relativePos);

            rotationPoint.x = 0;
            rotationPoint.z = 0;

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

    public static void MoveObjectForward(Transform p1, Vector3 input, float speed, float rotationSpeed, float speedMultiplier = 1) 
    {
        var speedM = speed * speedMultiplier;
        var stepSpeed = speedM * Time.fixedDeltaTime;
        Vector3 targetPosition = p1.position + p1.transform.forward * stepSpeed;
        //p1.position = Vector3.MoveTowards(p1.position, destination, stepSpeed);
        p1.position = Vector3.Lerp(p1.position, targetPosition, stepSpeed);

        Quaternion previousRotation = new Quaternion();

        if (input != Vector3.zero)
        {

            var relativePos = p1.transform.forward + input;
            Debug.DrawRay(p1.position, relativePos * 2f, Color.green);

            var rotationPoint = Quaternion.LookRotation(relativePos);

            rotationPoint.x = 0;
            rotationPoint.z = 0;

            p1.rotation = Quaternion.Slerp(p1.rotation, rotationPoint, rotationSpeed * Time.deltaTime);
            previousRotation = p1.rotation;

        }
   
    }

    public static void FocusOnObject(Transform originalTransform, Transform targetTransform, float rotationSpeed)
    {

        var relativePos = targetTransform.position - originalTransform.position;
        var rotationPoint = Quaternion.LookRotation(relativePos, originalTransform.up);

        rotationPoint.x = 0;
        rotationPoint.z = 0;

        originalTransform.rotation = Quaternion.Slerp(originalTransform.rotation, rotationPoint, rotationSpeed * Time.deltaTime);
        
    }


}
