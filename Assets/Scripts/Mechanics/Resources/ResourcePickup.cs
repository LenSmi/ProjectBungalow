using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ResourcePickup : MonoBehaviour, IPickup
{
    [Header("References")]
    public ResourceType resourceType;
    public Transform objTransform;
    public GameObject resourceModule;
    private GameObject playerSub;

    [Header("References")]
    public int resourceQuantity;
    public float pickUpDistance;
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

        if (Vector3.Distance(transform.position,playerSub.transform.position) < pickUpDistance)
        {
            transform.DOMove(playerSub.transform.position, speed);
        }

    }

    public void OnPickup()
    {
        Cargo cargo = GameManager.Instance().cargo();
        if (!cargo.IsCargoFull())
        {
            cargo.AddCargo(resourceType, resourceQuantity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == GameConstants.PlayerSubTag)
        {
            OnPickup(); 
        }
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }

}
