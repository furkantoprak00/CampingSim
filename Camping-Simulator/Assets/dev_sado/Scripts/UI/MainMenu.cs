using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public async void StartHost()
    {
        await HostSingleton.Instance.gameManager.StartHostAsync();

    }
}
