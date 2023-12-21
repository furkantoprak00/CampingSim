using UnityEngine;
using Unity.Netcode;

public class NetworkPickedup : NetworkBehaviour
{
    private NetworkVariable<bool> isPickedUp = new NetworkVariable<bool>();

    private void Start()
    {
        isPickedUp.OnValueChanged += HandlePickupChanged;
    }

    private void OnDestroy()
    {
        isPickedUp.OnValueChanged -= HandlePickupChanged;
    }

    [ServerRpc(RequireOwnership = false)]
    public void PickupObjectServerRpc()
    {
        isPickedUp.Value = true;
    }

    private void HandlePickupChanged(bool oldValue, bool newValue)
    {
        if (newValue)
        {
            gameObject.SetActive(false);
        }
    }

    public void PickupObject()
    {
        if (IsServer)
        {
            isPickedUp.Value = true;
        }
        else
        {
            PickupObjectServerRpc();
        }
    }
}
