using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 2.0f;
    public float runSpeed = 5.0f;
    public float crouchSpeed = 1.0f;
    public float mouseSensitivity = 2.0f;
    public PlayerInventory playerInventory;

    private Camera playerCamera;
    private CharacterController characterController;
    private float verticalSpeed;
    private bool isCrouching;

    public PlayerStats playerStats;
    public PlayerEquipment playerEquipment;

    [SerializeField] private float currentHealth;
    [SerializeField] private float currentHunger;
    [SerializeField] private float currentThirst;
    [SerializeField] private float currentTemperature;
    [SerializeField] private float currentMobility;
    [SerializeField] private float currentEnergy;

    private enum PlayerState
    {
        Idle,
        Walking,
        Running,
        Crouching
        // Add more states as needed
    }

    private PlayerState currentState = PlayerState.Idle;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerCamera = GetComponentInChildren<Camera>();
        characterController = GetComponent<CharacterController>();

        InitializePlayerStats();
        InitializePlayerEquipment();
    }

    private void InitializePlayerEquipment()
    {
        // Ekipman Uygulamas�
        ApplyEquipmentEffects(playerEquipment);
    }
    private void InitializePlayerStats()
    {
        // Oyuncu �zelliklerini PlayerStats a g�re ba�latma
        currentHealth = playerStats.startingHealth;
        currentHunger = playerStats.startingHunger;
        currentThirst = playerStats.startingThirst;
        currentTemperature = playerStats.startingTemperature;
        currentMobility = playerStats.startingMobility;
        currentEnergy = playerStats.startingEnergy;
    }

    public void AdjustHealth(float amount)
    {
        currentHealth += amount;
        // Sa�l�k ile ilgili i�leme
    }
    private void Update()
    {
        HandleMovementInput();
        HandleMouseLook();
        HandleItemInteraction();
        TryPickup(); // �tem pickleme kontrol sat�r�
    }

    private void TryPickup()
    {
        if (Input.GetKeyDown(KeyCode.E)) // �tem pickleme giri�i
        {
            // Toplama i�in Raycast
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 2f))
            {
                
                PickupItem pickupItem = hit.collider.GetComponent<PickupItem>();
                if (pickupItem != null)
                {
                    
                    pickupItem.PickUp();

                    // �tem envantere ekleme
                    AddItemToInventory(pickupItem.itemPrefab);
                }
            }
        }
    }

    private void AddItemToInventory(GameObject itemPrefab)
    {
        // Envantere e�ya ekleme
        // Oyuncunun envanterindeki slotu etkinle�tirme
        for (int i = 0; i < playerInventory.itemsInHand.Length; i++)
        {
            if (playerInventory.itemsInHand[i] == null)
            {
                playerInventory.itemsInHand[i] = itemPrefab;
                Debug.Log("Added item to inventory: " + itemPrefab.name);
                return;
            }
        }

        // Envanter full ise geri d�n�t mesaj�
        Debug.Log("Inventory is full. Cannot pick up " + itemPrefab.name);
    }


    private void HandleMovementInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0f;
        forward.Normalize();

        Vector3 right = playerCamera.transform.right;
        right.y = 0f;
        right.Normalize();

        Vector3 movement = (forward * vertical + right * horizontal).normalized;
      
        float speed = GetSpeed();
        characterController.Move(movement * speed * Time.deltaTime);
    
        verticalSpeed += Physics.gravity.y * Time.deltaTime;
        characterController.Move(new Vector3(0f, verticalSpeed, 0f) * Time.deltaTime);
    }

    private float GetSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !isCrouching)
        {
            return runSpeed * currentMobility;
        }
        else if (isCrouching)
        {
            return crouchSpeed * currentMobility;
        }
        else
        {
            return walkSpeed * currentMobility;
        }
    }

    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Fare hareketine g�re oyuncu karakterini d�nd�rme
        transform.Rotate(Vector3.up * mouseX, Space.World);

        // Oyuncu y eksenin de d�nd�rme
        Vector3 currentRotation = playerCamera.transform.eulerAngles;
        float newRotationX = Mathf.Clamp(currentRotation.x - mouseY, 0f, 90f);
        playerCamera.transform.rotation = Quaternion.Euler(newRotationX, currentRotation.y, 0f);
    }


    private void HandleItemInteraction()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            UseItemInHand();
        }
    }

    private void UseItemInHand()
    {
        for (int i = 0; i < playerInventory.itemsInHand.Length; i++)
        {
            if (playerInventory.itemsInHand[i] != null)
            {
                Debug.Log("Using item in hand: " + playerInventory.itemsInHand[i].name);
            }
        }
    }

    private void ToggleCrouch()
    {
        isCrouching = !isCrouching;
        if (isCrouching)
        {
            SetState(PlayerState.Crouching);
        }
        else
        {
            SetState(PlayerState.Idle);
        }
    }

    private void SetState(PlayerState newState)
    {
        if (currentState == newState)
            return;

        currentState = newState;
        // Animasyon veya di�er durumlar i�in
    }

    private void ApplyEquipmentEffects(PlayerEquipment equipment)
    {        
        if (equipment != null)
        {          
            currentMobility += equipment.coat.mobility;
            currentMobility += equipment.trousers.mobility;
            currentMobility += equipment.boots.mobility;
            currentMobility += equipment.hat.mobility;
            currentMobility += equipment.gloves.mobility;
            currentMobility += equipment.faceAccessory.mobility;

            currentTemperature += equipment.coat.coldResistance;
            currentTemperature += equipment.trousers.coldResistance;
            currentTemperature += equipment.boots.coldResistance;
            currentTemperature += equipment.hat.coldResistance;
            currentTemperature += equipment.gloves.coldResistance;
            currentTemperature += equipment.faceAccessory.coldResistance;
        }
    }
}
