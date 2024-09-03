using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ResourceItemScriptableObject", order = 1)]
public class ResourceItemScriptableObject : ScriptableObject
{
    public ResourceType resourceType;
    public int value;
}
