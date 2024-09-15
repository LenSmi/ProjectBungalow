using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RestorationRequirement
{
    public ResourceType Type;
    public ResourceItemData ResourceItemData;
    public int quantity;
    public bool IsMet = false;
}
