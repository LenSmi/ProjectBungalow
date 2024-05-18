using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ResourceModule : MonoBehaviour
{
    public ResourceType resourceType;
    public Transform objTransform;
    public GameObject resourceModule;
    public int resourceQuantity;
    public GameObject playerSub;
    public float pickDistance;
    public float speed;

    private void Start()
    {
        if(playerSub == null)
        {
            playerSub = GameObject.FindGameObjectWithTag(GameConstants.PlayerSubTag);
        }
    }

    public void FixedUpdate()
    {
        FindPlayer();
    }

    public void FindPlayer()
    {
        DOTween.Init();

        if (playerSub == null)
        {
            playerSub = GameObject.FindGameObjectWithTag(GameConstants.PlayerSubTag);
        }

        if (Vector3.Distance(transform.position,playerSub.transform.position) < pickDistance)
        {
            transform.DOMove(playerSub.transform.position, speed);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == GameConstants.PlayerSubTag)
        {
            Cargo cargo = FindObjectOfType<Cargo>();
            cargo.AddCargo(resourceType, resourceQuantity);
            Debug.Log("Enter");
            Destroy(gameObject);
        }
    }
}
