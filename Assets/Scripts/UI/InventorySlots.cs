using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlots : MonoBehaviour
{
    [SerializeField] Slot[] inventorySlots;

    private void Awake()
    {
        inventorySlots = GetComponentsInChildren<Slot>(true);
    }

    public bool SetItemToInventory(ItemData ItemData, int upgrade)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if(inventorySlots[i].SetItem(ItemData,upgrade))
                return true;
        }
        //�κ��丮 â�� �����ϴٴ� �˸�
        return false;
    }
}
