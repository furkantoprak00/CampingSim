using UnityEngine;

[CreateAssetMenu(fileName = "PlayerEquipment", menuName = "Player/PlayerEquipment")]
public class PlayerEquipment : ScriptableObject
{
    [Header("Coat")]
    public EquipmentItem coat;

    [Header("Trousers")]
    public EquipmentItem trousers;

    [Header("Boots")]
    public EquipmentItem boots;

    [Header("Hat")]
    public EquipmentItem hat;

    [Header("Gloves")]
    public EquipmentItem gloves;

    [Header("Face Accessory")]
    public EquipmentItem faceAccessory;
}

[System.Serializable]
public class EquipmentItem
{
    public string itemName;
    public int coldResistance;
    public float mobility;
}
