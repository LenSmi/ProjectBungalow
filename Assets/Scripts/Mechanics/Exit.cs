using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{

    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        door.SetActive(true);
        MinigameManager.QuotaReached += OpenDoor;
    }

    void OpenDoor()
    {
       door.SetActive(false);
    }
}
