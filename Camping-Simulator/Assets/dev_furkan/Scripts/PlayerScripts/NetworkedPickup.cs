using UnityEngine;
using Unity.Netcode;

public class NetworkedPickup : NetworkBehaviour
{
    private NetworkVariable<bool> isPickedUp = new NetworkVariable<bool>();

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

    private void Update()
    {
        if (IsLocalPlayer && Input.GetKeyDown(KeyCode.E))
        {
            PickupObjectServerRpc();
        }
    }

    private void OnPickupStateChanged(bool oldState, bool newState)
    {
        if (newState)
        {
            gameObject.SetActive(false);
        }
    }
}
