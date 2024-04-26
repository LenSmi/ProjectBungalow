using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Resource
{
    public string resourceName;
    public int quantity;
}
/// <summary>
/// This script manages cargo.
/// It has the current cargo and also the cargo that is housed on land
/// We want to be able to add and remove cargo from these containers.
/// </summary>
public class Cargo : MonoBehaviour
{
    [HideInInspector]
    public Dictionary<string, int> cargoInventory = new Dictionary<string, int>();

    [HideInInspector]
    public Dictionary<string, int> currentCargoInventory = new Dictionary<string, int>();

    public int maxCargo;
    public int currentCargo;

    public static Action AddItemsToCargo;
    
    public int previouslyAddedAmount;

    public void AddCargo(GameConstants.ResourceType type, int addedQuantity)
    {

        if (!currentCargoInventory.ContainsKey(type.ToString()))
        {
            currentCargoInventory.Add(type.ToString(), addedQuantity);
        }
        else
        {
            currentCargoInventory[type.ToString()] += addedQuantity;
        }

        var cargoCheck = currentCargo <= maxCargo ? currentCargo += addedQuantity : maxCargo;

        previouslyAddedAmount = addedQuantity;
        currentCargo = cargoCheck;


        AddItemsToCargo?.Invoke();
    }

    public void CargoLimitReached()
    {

    }



}
