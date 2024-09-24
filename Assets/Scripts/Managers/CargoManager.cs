using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum ResourceType
{
    JUNK,
    BIOMASS,
    PLASTICS,
    CREDITS
}

/// <summary>
/// This script manages cargo.
/// It has the current cargo and also the cargo that is housed on land
/// We want to be able to add and remove cargo from these containers.
/// </summary>
public class CargoManager : MonoBehaviour
{

    public CargoData GlobalCargoData;
    public CargoData DepositCargoData;
    public CargoData SubCargoData;

    public int maxCargo;
    public int currentCargo;
    public int previouslyAddedAmount;

    public static Action AddItemsToCargo;
    public static Action AddItemsToDeposit;



    public void AddCargo(ResourceItemData itemData, int quantity)
    {
        int cargoCheck = currentCargo < maxCargo ? itemData.Weight : 0;

        SubCargoData.AddResource(itemData, quantity);
        currentCargo += itemData.Weight;
        previouslyAddedAmount = itemData.Weight;

        AddItemsToCargo?.Invoke();
    }

    /// <summary>
    /// 
    /// </summary>
    public void AddCargoToDeposit()
    {

        foreach (var resource in SubCargoData.Resources.ToList())
        {
            DepositCargoData.AddResource(resource.Key, resource.Value);
            currentCargo -= resource.Key.Weight;
            SubCargoData.RemoveResource(resource.Key, resource.Value);
        }

        AddItemsToDeposit?.Invoke();
    }

    /// <summary>
    /// Adds current deposit to GlobalCargoData. This should be called when the player exits the trench.
    /// </summary>
    public void AddDepositToCargoInventory()
    {

        foreach (var resource in DepositCargoData.Resources.ToList())
        {
            GlobalCargoData.AddResource(resource.Key, resource.Value);
            DepositCargoData.RemoveResource(resource.Key, resource.Value);
        }

 

        currentCargo = 0;
    }

    public bool IsCargoFull()
    {
        return currentCargo >= maxCargo;

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Cargo inventory after adding resources:");
            foreach (var entry in SubCargoData.Resources)
            {
                Debug.Log($"Junk in subinventory{entry.Key}: {entry.Value} units");
            }

            foreach (var entry in DepositCargoData.Resources)
            {
                Debug.Log($"Junk in deposit{entry.Key}: {entry.Value} units");
            }
        }
    }
}
