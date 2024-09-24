using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ResourceItemScriptableObject", order = 1)]
[System.Serializable]
public class ResourceItemData : ScriptableObject
{
    public ResourceType resourceType;
    public int ItemValue;
    public int Quantity;
    public int Weight;
    public Sprite UIIcon;
}
