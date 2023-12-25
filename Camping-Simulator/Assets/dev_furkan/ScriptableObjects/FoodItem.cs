using UnityEngine;

[CreateAssetMenu(fileName = "New FoodItem", menuName = "Inventory/FoodItem")]
public class FoodItem : ScriptableObject
{
    public string itemName; // Item adý
    public float hungerRestoration; // Açlýk yenileme deðeri
    public float energyRestoration; // Enerji yenileme deðeri
    public float weight; // Aðýrlýk
    public Sprite itemIcon; // Item icon'u
}
