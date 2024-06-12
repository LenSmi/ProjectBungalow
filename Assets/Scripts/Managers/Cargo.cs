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
public class Cargo : MonoBehaviour
{
    private Dictionary<ResourceType, int> cargoInventory = new Dictionary<ResourceType, int>() { };
    private Dictionary<ResourceType, int> depositInventory = new Dictionary<ResourceType, int>() { };
    private Dictionary<ResourceType, int> subCargoInventory = new Dictionary<ResourceType, int>() { };
    public Dictionary<ResourceType, int> CargoInventory { get => cargoInventory; set => cargoInventory = value; }
    public Dictionary<ResourceType, int> DepositInventory { get => depositInventory; set => depositInventory = value; }
    public Dictionary<ResourceType, int> SubCargoInventory { get => subCargoInventory; set => subCargoInventory = value; }


    public int maxCargo;
    public int currentCargo;
    public int previouslyAddedAmount;

    public static Action AddItemsToCargo;
    public static Action AddItemsToDeposit;



    public void AddCargo(ResourceType type, int addedQuantity)
    {

        var cargoCheck = currentCargo < maxCargo ? addedQuantity : 0;

        if (!SubCargoInventory.ContainsKey(type))
        {
            SubCargoInventory.Add(type, addedQuantity);
            currentCargo += cargoCheck;
        }
        else 
        {
            SubCargoInventory[type] += cargoCheck;
            currentCargo += cargoCheck;
        }

        previouslyAddedAmount = addedQuantity;

        AddItemsToCargo?.Invoke();
    }

    public void AddCargoToDeposit()
    {

        foreach (var key in SubCargoInventory.ToList())
        {
            int value = key.Value;

            if (!DepositInventory.ContainsKey(key.Key))
            {
                try
                {
                    DepositInventory.Add(key.Key, value);
                }
                catch (ArgumentException) 
                {
                    Debug.LogError("Could not add to deposit");
                }
               

            }
            else
            {
                DepositInventory[key.Key] += value;
            }

            currentCargo -= key.Value;
            SubCargoInventory[key.Key] -= value;
        }

        AddItemsToDeposit?.Invoke();
    }

    public void AddDepositToCargoInventory()
    {

        foreach (var key in DepositInventory.ToList())
        {
            int value = key.Value;

            if (!CargoInventory.ContainsKey(key.Key))
            {
                try
                {
                    CargoInventory.Add(key.Key, value);
                }
                catch (ArgumentException)
                {
                    Debug.LogError("Could not add to deposit");
                }


            }
            else
            {
                CargoInventory[key.Key] += value;
            }

            DepositInventory[key.Key] -= value;
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
