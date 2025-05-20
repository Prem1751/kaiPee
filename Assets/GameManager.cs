using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public InventoryPanel inventoryPanel;
    public void OpenInventoryPanel()
    {
       inventoryPanel.gameObject.SetActive(true);
        inventoryPanel.OnOpen();
       Cursor.visible = true;
       Cursor.lockState = CursorLockMode.None;
       Time.timeScale = 0f;
    }
    public void CloseInventoryPanel() 
    {
        inventoryPanel.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }

    public float timeCounter = 30f;
    public Itemdata targetItem;
    public int targetAmout = 5;

    public TMP_Text timeCounterText;
    public Image targetItemIcon;
    public TMP_Text targetCurrentAmountText;

    public bool isPlayerWine = false;

    private void Start()
    {
        targetItemIcon.sprite = targetItem.ItemIcon;
    }

    private void Update()
    {
        if (isPlayerWine)
            return;
        if (timeCounter > 0f)
        {
            timeCounter -= Time.deltaTime;
            timeCounterText.text = timeCounter.ToString();
            targetCurrentAmountText.text = "X " + (targetAmout - InventoryManager.instance.GetItemAmount(targetItem)).ToString();

            if (InventoryManager.instance.GetItemAmount(targetItem) >= targetAmout)
            {
                Debug.Log("Player Win");
            }
        }
        else
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    
}
