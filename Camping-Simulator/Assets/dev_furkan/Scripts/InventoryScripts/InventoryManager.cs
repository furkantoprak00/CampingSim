using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public List<InventorySlot> inventory = new List<InventorySlot>();

    void Start()
    {
        // Ba�lang��ta envanter slotlar�n� ba�lat
        InitializeInventorySlots(8); // �rnek olarak 10 slot
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
                break; // Item eklendi, d�ng�den ��k
            }
            else if (slot.item == item && slot.IsStackable)
            {
                slot.amount += amount;
                if (slot.amount > slot.MaxStack)
                {
                    slot.amount = slot.MaxStack;
                }
                break; // Item eklendi, d�ng�den ��k
            }
        }

        UpdateUI(); // Envanter UI's�n� g�ncelle
    }

    void UpdateUI()
    {
        // Burada, envanter UI elementlerinizi g�ncelleyin.
        // �rne�in, her slot i�in bir UI elementi g�ncelleyebilirsiniz.
    }

    // Di�er fonksiyonlar...
}
