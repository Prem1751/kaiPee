using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class ItemBase : MonoBehaviour, IInteractable
{
    public Itemdata data;

    public void Interact()
    {
        Debug.Log("interation item : " + data.name);
        InventoryManager.instance.AddItem(data);
        Destroy(gameObject);
    }
}