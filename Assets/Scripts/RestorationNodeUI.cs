using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RestorationNodeUI : MonoBehaviour
{
    public GameObject UINodePrefab;
    public Canvas Canvas;
    public GameObject NodeParent;
    public RestorationNode RestorationNode;
    public Color MetColor;
    public Color NotMetColor;

    private List<GameObject> nodes = new List<GameObject>();


    public void Start()
    {
       NodeParent.SetActive(false);
       SetRequirements();
       UpdateRequirements();
    }

    public void SetRequirements()
    {

        Debug.Log("Requirements: " + RestorationNode.requiredResources.Count);

        foreach (var requirement in RestorationNode.requiredResources)
        {
            Debug.Log("Requirements: " + requirement.Type.ToString());

            GameObject node = Instantiate(UINodePrefab, NodeParent.transform.position, Quaternion.identity);
            node.transform.SetParent(NodeParent.transform, true);

            Image nodeIcon = node.transform.Find("Icon").GetComponent<Image>();
            Sprite sprite = requirement.ResourceItemData.UIIcon;
            nodeIcon.sprite = sprite;

            nodes.Add(node);
        }

    }

    public void UpdateRequirements()
    {
        var zipped = nodes.Zip(RestorationNode.requiredResources, (node, requirement) => new { node, requirement });

        foreach (var pair in zipped)
        {
            Image nodeImage = pair.node.GetComponent<Image>();

            if (pair.requirement.IsMet)
            {
                nodeImage.color = MetColor;
            }
            else
            {
                nodeImage.color = NotMetColor;
            }

            TextMeshProUGUI nodeText = pair.node.GetComponentInChildren<TextMeshProUGUI>();
            nodeText.text = "X" + pair.requirement.quantity.ToString();
        }

    }
}
