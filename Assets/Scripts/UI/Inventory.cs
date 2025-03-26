using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] Button inventoryButton;
    [SerializeField] GameObject inventoryWindow;
    public InventorySlots inventorySlots;
    public Slot selectItemSlot;
    [SerializeField] TextMeshProUGUI selectItemName;
    [SerializeField] TextMeshProUGUI selectItemDescription;
    [SerializeField] GameObject equipButton;
    [SerializeField] GameObject upgradeButton;
    [SerializeField] GameObject sellButton;

    bool isRemove;

    private void Awake()
    {
        inventorySlots = GetComponentInChildren<InventorySlots>();
    }
    private void Start()
    {
        inventoryButton.onClick.AddListener(ClickInventoryIcon);
    }
    private void OnEnable()
    {
        selectItemSlot?.ActiveSelectImg(false);
        selectItemSlot = null;
        selectItemName.gameObject.SetActive(false);
        selectItemDescription.gameObject.SetActive(false);
    }
    void ClickInventoryIcon()
    {
        inventoryWindow.SetActive(!inventoryWindow.activeSelf);
    }
    public bool SetItemToInventory(ItemData ItemData, int upgrade)
    {
        return inventorySlots.SetItemToInventory(ItemData, upgrade);
    }
    public void SetSelectItem(Slot slot)
    {
        if (selectItemSlot == slot)
            return;
        selectItemSlot?.ActiveSelectImg(false);
        selectItemSlot = slot;
        if (selectItemSlot == null)
        {
            upgradeButton.SetActive(false);
            sellButton.SetActive(false);
            equipButton.SetActive(false);
            selectItemName.gameObject.SetActive(false);
            selectItemDescription.gameObject.SetActive(false);
            return;
        }
        selectItemSlot.ActiveSelectImg(true);
        ItemData baseItemData = slot.itemData;
        selectItemName.text = baseItemData.name;
        selectItemDescription.text = baseItemData.description;
        selectItemName.gameObject.SetActive(true);
        selectItemDescription.gameObject.SetActive(true);
        upgradeButton.SetActive(true);
        sellButton.SetActive(true);
        equipButton.SetActive(true);

    }
    public void OnClickEquipButton()
    {

    }
    public void OnClickSellButton()
    {
        selectItemSlot.SellItem();
    }
}
