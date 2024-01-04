using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    public ScriptableObject item; // Item'ýn kendisi
    public int amount; // Miktarý

    public bool IsStackable => item is IStackable;
    public int MaxStack => (item as IStackable)?.MaxStack ?? 1;

    public InventorySlot()
    {
        item = null;
        amount = 0;
    }
    public InventorySlot(ScriptableObject newItem, int newAmount)
    {
        item = newItem;
        amount = newAmount;
    }

    // Stacklemeyi destekleyen bir item eklemek için
    public bool AddToStack(int amountToAdd)
    {
        if (!IsStackable) return false;

        int totalAmount = amount + amountToAdd;
        if (totalAmount <= MaxStack)
        {
            amount = totalAmount;
            return true;
        }

        return false;
    }
}
