using UnityEngine;

[CreateAssetMenu(fileName = "New FoodItem", menuName = "Inventory/FoodItem")]
public class FoodItem : ScriptableObject, IStackable
{
    public string itemName; // Item ad�
    public float hungerRestoration; // A�l�k yenileme de�eri
    public float energyRestoration; // Enerji yenileme de�eri
    public float weight; // A��rl�k
    public Sprite itemIcon; // Item icon'u

    public int maxStack = 5; // Maksimum stack boyutu
    public int MaxStack => maxStack;
}
