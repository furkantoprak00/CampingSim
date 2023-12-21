using UnityEngine;
using Unity.Netcode;

public class NetworkPlayers : NetworkBehaviour
{
    public GameObject cameraObject;
    public MonoBehaviour[] localOnlyComponents;

    private void Start()
    {
        if (IsOwner)
        {
            cameraObject.SetActive(true);
            foreach (var component in localOnlyComponents)
            {
                component.enabled = true;
            }
        }
        else
        {
            cameraObject.SetActive(false);
            foreach (var component in localOnlyComponents)
            {
                component.enabled = false;
            }
        }
    }
}
