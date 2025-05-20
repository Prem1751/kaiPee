using UnityEngine;

[CreateAssetMenu(fileName = "NameItemData",menuName ="Workshop/ItemData")]
public class Itemdata : ScriptableObject
{
    public string ItemName;
    public string description;
    public string more;
    public Sprite ItemIcon;

}
