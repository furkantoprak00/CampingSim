using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInventory", menuName = "Inventory/PlayerInventory")]
public class PlayerInventory : ScriptableObject
{
    public GameObject[] itemsInHand = new GameObject[3]; // E�yay� oyuncunun elinde saklayacak k�s�m
}
