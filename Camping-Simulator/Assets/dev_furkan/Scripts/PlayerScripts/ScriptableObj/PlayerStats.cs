using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public float startingHealth = 100f;
    public float startingHunger = 100f;
    public float startingThirst = 100f;
    public float startingTemperature = 98.6f;
    public float startingMobility = 5f;
    public float startingEnergy = 100f;

    public PlayerEquipment startingEquipment;
}
