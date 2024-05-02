using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Resource
{
    public string resourceName;
    public int quantity;
    public string description;
}

public class Junk : Resource
{
   
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

    public Dictionary<string, int> depositInventory = new Dictionary<string, int>();

    [HideInInspector]
    public Dictionary<string, int> subCargoInventory = new Dictionary<string, int>();

    

    public int maxCargo;
    public int currentCargo;

    public static Action AddItemsToCargo;
    
    public int previouslyAddedAmount;

    public void AddCargo(GameConstants.ResourceType type, int addedQuantity)
    {

        if (subCargoInventory.ContainsKey(type.ToString()))
        {
            subCargoInventory.Add(type.ToString(), addedQuantity);
            currentCargo += addedQuantity;
        }
        else if(subCargoInventory.ContainsKey(type.ToString()))
        {
            subCargoInventory[type.ToString()] += addedQuantity;
            var cargoCheck = currentCargo < maxCargo ? currentCargo += addedQuantity : currentCargo += 0;
            currentCargo = cargoCheck;
        }



        previouslyAddedAmount = addedQuantity;

        AddItemsToCargo?.Invoke();
    }

    public void AddCargoToDeposit()
    {

    }

    public void AddDepositToCargoInventory()
    {

    }

    public void CargoLimitReached()
    {

    }



}
