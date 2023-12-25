using UnityEngine;

[CreateAssetMenu(fileName = "New EquipmentItem", menuName = "Inventory/EquipmentItem")]
public class EquipmentItem : ScriptableObject
{
    public string itemName; // Item ad�
    public float weatherResistance; // Hava ko�ullar� direnci
    public float durability; // Dayan�kl�l�k
    public float mobility; // Mobilite
    public float weight; // A��rl�k
    public Sprite itemIcon; // Item icon'u
}
