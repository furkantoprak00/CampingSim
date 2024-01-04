using UnityEngine;
using Unity.Netcode;

public class NetworkedPickup : NetworkBehaviour
{
    private NetworkVariable<bool> isPickedUp = new NetworkVariable<bool>();
    public ScriptableObject itemData; // Bu item'ýn verisi

    private void Start()
    {
        isPickedUp.OnValueChanged += OnPickupStateChanged;
    }

    private void OnDestroy()
    {
        isPickedUp.OnValueChanged -= OnPickupStateChanged;
    }

    [ServerRpc(RequireOwnership = false)]
    public void PickupObjectServerRpc()
    {
        isPickedUp.Value = true;
    }

    private void OnPickupStateChanged(bool oldState, bool newState)
    {
        if (newState)
        {
            AddItemToPlayerInventory();
            gameObject.SetActive(false);
        }
    }

    private void AddItemToPlayerInventory()
    {
        if (IsServer && IsOwner)
        {
            // Burada, oyuncunun InventoryManager'ýna eriþip item'ý ekleyin.
            var playerInventory = NetworkManager.Singleton.ConnectedClients[OwnerClientId].PlayerObject.GetComponent<InventoryManager>();
            playerInventory.AddItem(itemData);
        }
    }
}
