using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CargoData", order = 0)]
public class CargoData : ScriptableObject
{
    //List reference
    public Dictionary<ResourceItemData, int> Resources = new Dictionary<ResourceItemData, int>();

    public void AddResource(ResourceItemData item, int quantity)
    {
        if (Resources.ContainsKey(item))
        {
            Resources[item] += quantity;
        }
        else
        {
            Resources.Add(item, quantity);
        }
    }

    public void RemoveResource(ResourceItemData item, int amount)
    {
        if (Resources.ContainsKey(item))
        {
            Resources[item] = Mathf.Max(0, Resources[item] - amount);
        }
    }

}
