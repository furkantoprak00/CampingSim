using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public List<InventorySlot> inventory = new List<InventorySlot>();

    void Start()
    {
        // Baþlangýçta envanter slotlarýný baþlat
        InitializeInventorySlots(8); // Örnek olarak 10 slot
    }

    void InitializeInventorySlots(int slotCount)
    {
        for (int i = 0; i < slotCount; i++)
        {
            inventory.Add(new InventorySlot());
        }
    }

    public void AddItem(ScriptableObject item, int amount = 1)
    {
        foreach (var slot in inventory)
        {
            if (slot.item == null)
            {
                slot.item = item;
                slot.amount = amount;
                break; // Item eklendi, döngüden çýk
            }
            else if (slot.item == item && slot.IsStackable)
            {
                slot.amount += amount;
                if (slot.amount > slot.MaxStack)
                {
                    slot.amount = slot.MaxStack;
                }
                break; // Item eklendi, döngüden çýk
            }
        }

        UpdateUI(); // Envanter UI'sýný güncelle
    }

    void UpdateUI()
    {
        // Burada, envanter UI elementlerinizi güncelleyin.
        // Örneðin, her slot için bir UI elementi güncelleyebilirsiniz.
    }

    // Diðer fonksiyonlar...
}
