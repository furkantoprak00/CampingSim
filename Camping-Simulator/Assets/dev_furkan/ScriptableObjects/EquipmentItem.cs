using UnityEngine;

[CreateAssetMenu(fileName = "New EquipmentItem", menuName = "Inventory/EquipmentItem")]
public class EquipmentItem : ScriptableObject
{
    public string itemName; // Item adý
    public float weatherResistance; // Hava koþullarý direnci
    public float durability; // Dayanýklýlýk
    public float mobility; // Mobilite
    public float weight; // Aðýrlýk
    public Sprite itemIcon; // Item icon'u
}
