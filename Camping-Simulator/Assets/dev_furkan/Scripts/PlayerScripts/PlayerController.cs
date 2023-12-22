using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : NetworkBehaviour
{
    [SerializeField] private float walkSpeed = 3.0f;
    [SerializeField] private float runSpeed = 6.0f;
    [SerializeField] private float weight = 70f;
    [SerializeField] private float interactionDistance = 2f;
    [SerializeField] private LayerMask interactableLayer;
    private float xRotation = 0f;

    private Rigidbody rb;
    private Camera cam;
    private float currentSpeed;
    private Vector3 movementInput;
    private bool isRunning = false;

    public override void OnNetworkSpawn()
    {
        if (!IsOwner)
        {
            cam.enabled = false; 
            return;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    private void Update()
    {
        if (IsOwner)
        {
            ProcessInput();
            RotateCharacter();
            AdjustSpeedBasedOnWeight();
            TryInteract();
        }
    }

    private void FixedUpdate()
    {
        if (IsOwner)
        {
            MoveCharacter();
        }
    }

    private void ProcessInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movementInput = new Vector3(horizontal, 0, vertical);
        isRunning = Input.GetKey(KeyCode.LeftShift);
    }

    private void MoveCharacter()
    {
        Vector3 movement = transform.TransformDirection(movementInput) * currentSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }

    private void RotateCharacter()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -70f, 70f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    private void AdjustSpeedBasedOnWeight()
    {
        currentSpeed = isRunning ? runSpeed : walkSpeed;
        currentSpeed *= 1 - (weight - 70) / 150;
    }

    private void TryInteract()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

            if (Physics.Raycast(ray, out hit, interactionDistance))
            {
                NetworkedPickup networkedPickup = hit.collider.GetComponent<NetworkedPickup>();
                if (networkedPickup != null)
                {
                    networkedPickup.PickupObjectServerRpc();
                }
            }
        }
    }
}
