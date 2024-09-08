using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public Transform TransformPoint;
    public Transform DoorObjectTransform;
    private Vector3 _initialPos;

    // Start is called before the first frame update
    void Start()
    {

        var MinigameManager = GameManager.Instance().MinigameManager();
        MinigameManager.QuotaReached += OpenDoor;
        _initialPos = DoorObjectTransform.localPosition;

        if (DoorObjectTransform)
        {
            DoorObjectTransform.transform.localPosition = _initialPos;
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
