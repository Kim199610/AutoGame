using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI upgradeText;
    [SerializeField] TextMeshProUGUI itemNameText;
    public GameObject selectedImg;
    [SerializeField] Image icon;
    public int Upgrade { get; private set; }



    public ItemData itemData;

    private void Start()
    {
        updateSlot();
    }
    public bool SetItem(ItemData inputItemData, int upgradeNum)
    {
        if (itemData == null)
        {
            itemData = inputItemData;
            Upgrade = upgradeNum;
            updateSlot();
            return true;
        }
        
        return false;
    }

    void updateSlot()
    {
        if (itemData != null)
        {
            if(Upgrade >= 1)
            {
                upgradeText.gameObject.SetActive(true);
                upgradeText.text = Upgrade.ToString();
            }
            icon.gameObject.SetActive(true);
            icon.sprite = itemData.icon;
        }
        else
        {
            upgradeText.gameObject.SetActive(false);
            icon.gameObject.SetActive(false);
        }
    }
    public void EquipItem()
    {
        
    }

    public void OnSlotClick()
    {
        if (itemData == null)
        {
            UIManager.Instance.inventory.SetSelectItem(null);
        }
        else
        {
            UIManager.Instance.inventory.SetSelectItem(this);
        }
    }
    public void ActiveSelectImg(bool value)
    {
        selectedImg.SetActive(value);
    }
    public void SellItem()
    {
        //sell
        itemData = null;
        updateSlot();
    }
}
