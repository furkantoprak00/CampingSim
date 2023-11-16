using UnityEngine;

[CreateAssetMenu(fileName = "Equipment", menuName = "Equipment/GeneralEquipment")]
public class EquipmentScriptableObject : ScriptableObject
{
    public string equipmentName;
    public float mobility;
    public int coldResistance;
    // Add more properties as needed
}
