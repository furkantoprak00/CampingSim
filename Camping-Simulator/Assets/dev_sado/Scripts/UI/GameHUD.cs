using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.Netcode;
using UnityEngine;

public class GameHUD : NetworkBehaviour
{
   // Canvalaunchercontrol Canvalaunchercontrol;


    public override void OnNetworkSpawn()
    {
        //while (Canvalaunchercontrol == null)
        //{

        //    if (!IsOwner)
        //    { return; }
        //    Canvalaunchercontrol = GameObject.Find("VideoPoint").GetComponent<Canvalaunchercontrol>();

        //}
    }
    public void LeaveGame()
    {
        if (NetworkManager.Singleton.IsHost)
        {
            HostSingleton.Instance.gameManager.ShutDown();
            

        }
        ClientSingleton.Instance.GameManager.Disconnect();
        GameObject.Find("Network Manager").GetComponent<VivoxPlayer>().OnUserLoggedOut();
    }
    //public void StartVideo()
    //{
    //    Canvalaunchercontrol.Spawner();
    //}
   
}
