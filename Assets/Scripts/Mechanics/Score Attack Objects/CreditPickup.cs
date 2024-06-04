using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CoinPickup : MonoBehaviour, IPickup
{
    [Header("References")]
    public ResourceType resourceType;
    private GameObject playerSub;

    [Header("Variables")]
    public int ResourceQuantity;
    public float PickUpDistance;
    public float MovementSpeed;
    public float ScoreValue;
    public void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, playerSub.transform.position) < PickUpDistance)
        {
            FindPlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        OnPickup();
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
        Cargo cargo = GameManager.Instance().cargo();
        if (!cargo.IsCargoFull())
        {
            cargo.AddCargo(resourceType, ResourceQuantity);
            Destroy(gameObject);
        }
    }

    public void CalculateScore()
    {
        throw new System.NotImplementedException();
    }
}
