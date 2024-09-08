using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public Transform InitialTransformPoint;
    public Transform TransformPoint;
    public Transform DoorObjectTransform;

    // Start is called before the first frame update
    void Start()
    {
        var MinigameManager = GameManager.Instance().MinigameManager();
        MinigameManager.QuotaReached += OpenDoor;

        if (DoorObjectTransform)
        {
            DoorObjectTransform.transform.position = InitialTransformPoint.localPosition;
        }
        else
        {
            DoorObjectTransform = transform.Find("Door");
        }

    }

    void OpenDoor()
    {
        if (DoorObjectTransform)
        {
            DoorObjectTransform.transform.position = TransformPoint.position;
        }
        else
        {
            DoorObjectTransform = transform.Find("Door");
        }
    }

    private void OnDestroy()
    {
        var MinigameManager = GameManager.Instance().MinigameManager();
        MinigameManager.QuotaReached -= OpenDoor;
    }
}
