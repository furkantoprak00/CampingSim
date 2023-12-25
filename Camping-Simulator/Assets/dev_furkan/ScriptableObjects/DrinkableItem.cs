using UnityEngine;

[CreateAssetMenu(fileName = "New DrinkableItem", menuName = "Inventory/DrinkableItem")]
public class DrinkableItem : ScriptableObject
{
    public string itemName; // Item ad�
    public float thirstRestoration; // Susuzluk yenileme de�eri
    public float energyRestoration; // Enerji yenileme de�eri
    public float weight; // A��rl�k
    public Sprite itemIcon; // Item icon'u
}
