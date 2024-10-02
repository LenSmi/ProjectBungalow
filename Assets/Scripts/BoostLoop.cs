using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class BoostLoop : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == GameConstants.PlayerSubTag)
        {
            var mover = other.gameObject.GetComponent<SubMover>();
            mover.StartCoroutine(mover.IEForcedDash());
        }
    }
}
