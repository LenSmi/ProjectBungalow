using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum ResourceType
{
    JUNK,
    BIOMASS,
    PLASTICS
}

/// <summary>
/// This script manages cargo.
/// It has the current cargo and also the cargo that is housed on land
/// We want to be able to add and remove cargo from these containers.
/// </summary>
public class Cargo : MonoBehaviour
{

    [HideInInspector]
    public Dictionary<ResourceType, int> cargoInventory = new Dictionary<ResourceType, int>();

    public Dictionary<ResourceType, int> depositInventory = new Dictionary<ResourceType, int>();

    [HideInInspector]
    public Dictionary<ResourceType, int> subCargoInventory = new Dictionary<ResourceType, int>();

    

    public int maxCargo;
    public int currentCargo;
    public int previouslyAddedAmount;

    public static Action AddItemsToCargo;
    public static Action AddItemsToDeposit;



    public void AddCargo(ResourceType type, int addedQuantity)
    {
        var cargoCheck = currentCargo < maxCargo ? addedQuantity : 0;

        if (!subCargoInventory.ContainsKey(type))
        {
            subCargoInventory.Add(type, addedQuantity);
            currentCargo += cargoCheck;
        }
        else 
        {
            subCargoInventory[type] += cargoCheck;
            currentCargo += cargoCheck;
        }

        previouslyAddedAmount = addedQuantity;

        AddItemsToCargo?.Invoke();
    }

    public void AddCargoToDeposit()
    {
        //Check if deposit is full
        //Check if keys exists ? if not then add keys
        //Add resources to deposit cargo
        //Remove resources from subinventory

        foreach (var key in subCargoInventory.ToList())
        {
            int value = key.Value;

            if (!depositInventory.ContainsKey(key.Key))
            {
                try
                {
                    depositInventory.Add(key.Key, value);
                }
                catch (ArgumentException) 
                {
                    Debug.LogError("Could not add to deposit");
                }
               

            }
            else
            {
                depositInventory[key.Key] += value;
            }

            currentCargo -= key.Value;
            subCargoInventory[key.Key] -= value;
        }

        AddItemsToDeposit?.Invoke();

    }

    public void AddDepositToCargoInventory()
    {
        //Add deposit to main cargo
        foreach (var key in depositInventory.ToList())
        {
            int value = key.Value;

            if (!cargoInventory.ContainsKey(key.Key))
            {
                try
                {
                    cargoInventory.Add(key.Key, value);
                }
                catch (ArgumentException)
                {
                    Debug.LogError("Could not add to deposit");
                }


            }
            else
            {
                cargoInventory[key.Key] += value;
            }

            depositInventory[key.Key] -= value;
        }
    }

    public bool IsCargoFull()
    {
        var isCargoFull = currentCargo < maxCargo ? false : true;

        return isCargoFull;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Cargo inventory after adding resources:");
            foreach (var entry in subCargoInventory)
            {
                Debug.Log($"Junk in subinventory{entry.Key}: {entry.Value} units");
            }

            foreach (var entry in depositInventory)
            {
                Debug.Log($"Junk in deposit{entry.Key}: {entry.Value} units");
            }
        }
    }



}
