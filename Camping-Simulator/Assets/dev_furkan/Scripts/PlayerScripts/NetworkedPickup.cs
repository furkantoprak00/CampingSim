using UnityEngine;
using Unity.Netcode;

public class NetworkedPickup : NetworkBehaviour
{
    private NetworkVariable<bool> isPickedUp = new NetworkVariable<bool>();

    private void Start()
    {
        Debug.Log("NetworkedPickup script started.");
        isPickedUp.OnValueChanged += OnPickupStateChanged;
    }

    private void OnDestroy()
    {
        isPickedUp.OnValueChanged -= OnPickupStateChanged;
    }

    [ServerRpc(RequireOwnership = false)]
    public void PickupObjectServerRpc()
    {
        Debug.Log("�al��t� Server �a��rma");
        isPickedUp.Value = true;
    }

    private void Update()
    {
      
    }

    private void OnPickupStateChanged(bool oldState, bool newState)
    {
        Debug.Log($"�al��t� clientlerde: {newState}");
        if (newState)
        {
            gameObject.SetActive(false);
        }
    }
}
