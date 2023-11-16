using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInventory", menuName = "Inventory/PlayerInventory")]
public class PlayerInventory : ScriptableObject
{
    public GameObject[] itemsInHand = new GameObject[3]; // Eþyayý oyuncunun elinde saklayacak kýsým
}
