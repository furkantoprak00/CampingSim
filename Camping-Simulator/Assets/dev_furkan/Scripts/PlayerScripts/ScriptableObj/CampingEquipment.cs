using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CampingEquipment", menuName = "Equipment/CampingEquipment")]
public class CampingEquipment : ScriptableObject
{
    public string equipmentName;
    public float mobility;
    public int coldResistance;
}
