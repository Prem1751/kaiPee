using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryPanel : MonoBehaviour
{
    public Image selectIcon;
    public TMP_Text descriptionText;
    public TMP_Text more;
    public Transform rightPanelTransform;
    public GameObject itemButtonPrefab;

    public void OnOpen()
    {
        for (int i = rightPanelTransform.childCount - 1; i >= 0; i--) {
            Destroy(rightPanelTransform.GetChild(i).gameObject);
        }
        for(int i = 0; i < InventoryManager.instance.inventoryList.Count; i++)
        {
            GameObject itemButtonObj = Instantiate(itemButtonPrefab, rightPanelTransform);
            Itembutton itembuttonComp = itemButtonObj.GetComponent<Itembutton>();
            itembuttonComp.data = InventoryManager.instance.inventoryList[i];
            itembuttonComp.icon.sprite = itembuttonComp.data.ItemIcon;
            Button button = itembuttonComp.GetComponent<Button>();
            button.onClick.AddListener(() =>
            {
                selectIcon.sprite = itembuttonComp.data.ItemIcon;
                descriptionText.text = itembuttonComp.data.description;
                more.text = itembuttonComp.data.more;
            });
        }
    }
}
