using UnityEngine;

[CreateAssetMenu(fileName = "New DrinkableItem", menuName = "Inventory/DrinkableItem")]
public class DrinkableItem : ScriptableObject
{
    public string itemName; // Item adý
    public float thirstRestoration; // Susuzluk yenileme deðeri
    public float energyRestoration; // Enerji yenileme deðeri
    public float weight; // Aðýrlýk
    public Sprite itemIcon; // Item icon'u
}
