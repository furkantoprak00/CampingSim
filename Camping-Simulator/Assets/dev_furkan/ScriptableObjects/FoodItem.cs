using UnityEngine;

[CreateAssetMenu(fileName = "New FoodItem", menuName = "Inventory/FoodItem")]
public class FoodItem : ScriptableObject, IStackable
{
    public string itemName; // Item adý
    public float hungerRestoration; // Açlýk yenileme deðeri
    public float energyRestoration; // Enerji yenileme deðeri
    public float weight; // Aðýrlýk
    public Sprite itemIcon; // Item icon'u

    public int maxStack = 5; // Maksimum stack boyutu
    public int MaxStack => maxStack;
}
