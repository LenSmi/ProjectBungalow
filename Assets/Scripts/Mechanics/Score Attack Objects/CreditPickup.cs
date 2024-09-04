using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CoinPickup : MonoBehaviour, IPickup
{
    [Header("References")]
    public ResourceItemData itemData;
    private GameObject playerSub;

    [Header("Variables")]
    public int ResourceQuantity;
    public float PickUpDistance;
    public float MovementSpeed;
    public int AddedQuantity;
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
        CargoManager cargo = GameManager.Instance().Cargo();
        if (!cargo.IsCargoFull())
        {
            cargo.AddCargo(itemData, AddedQuantity);
            Destroy(gameObject);
        }
    }

    public void CalculateScore()
    {
        throw new System.NotImplementedException();
    }
}
