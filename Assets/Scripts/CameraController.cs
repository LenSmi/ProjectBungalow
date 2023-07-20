using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform playerTarget;
    public Vector3 offset;
    public float lerpTime;
    public float forwardOffset;
    private void FixedUpdate()
    {
        //Debug.Log(PlayerMovement_v1.isMoving); JUHO silence
        LerpCamera();
    }

    void LerpCamera()
    {
        //Debug.Log("CAM LERP");
        Vector3 currentPos = transform.position;
        Vector3 wantedPos = playerTarget.position;
        wantedPos.y += offset.y;
        wantedPos.x += offset.x;
        wantedPos.z += offset.z;
        wantedPos += playerTarget.right * forwardOffset;
        transform.position = Vector3.Lerp(currentPos, wantedPos, lerpTime * Time.deltaTime);


    }
}
