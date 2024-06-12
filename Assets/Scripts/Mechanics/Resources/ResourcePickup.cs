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

    [Header("Variables")]
    public int ResourceQuantity;
    public float PickUpDistance;
    public float MovementSpeed;
    public int ScoreAttackValue;

    private void Start()
    {
        if(playerSub == null)
        {
            playerSub = GameObject.FindGameObjectWithTag(GameConstants.PlayerSubTag);
        }
    }

    public void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, playerSub.transform.position) < PickUpDistance)
        {
            FindPlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == GameConstants.PlayerSubTag)
        {
            OnPickup();
        }
    }

    public void FindPlayer()
    {
        DOTween.Init();

        if (playerSub == null)
        {
            playerSub = GameObject.FindGameObjectWithTag(GameConstants.PlayerSubTag);
        }

        transform.DOMove(playerSub.transform.position, MovementSpeed);

    }

    public void OnPickup()
    {

        MinigameManager manager = GameManager.Instance().minigameManager();
        manager.UpdateQuota(ScoreAttackValue);

        Cargo cargo = GameManager.Instance().cargo();

        if (!cargo.IsCargoFull())
        {
            cargo.AddCargo(resourceType, ResourceQuantity);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }

    public void CalculateScore()
    {
        throw new System.NotImplementedException();
    }
}
