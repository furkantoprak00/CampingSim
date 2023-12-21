using UnityEngine;
using Unity.Netcode;

public class InteractionsController : NetworkBehaviour
{
    [SerializeField] private float interactDistance = 2f;
    [SerializeField] private LayerMask interactableLayer;

    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (IsLocalPlayer && Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    private void TryInteract()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, interactableLayer))
        {
            NetworkPickedup pickup = hit.collider.GetComponent<NetworkPickedup>();
            if (pickup != null)
            {
                pickup.PickupObject();
            }
        }
    }
}
