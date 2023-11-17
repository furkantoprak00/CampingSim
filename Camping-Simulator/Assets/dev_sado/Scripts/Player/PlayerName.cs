using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

public class PlayerName : NetworkBehaviour
{


    public NetworkVariable<FixedString32Bytes> playerName = new NetworkVariable<FixedString32Bytes>();
    public static event Action<PlayerName> OnPlayerSpawned;
    public static event Action<PlayerName> OnPlayerDespawned;
    public override void OnNetworkSpawn()
    {
        
        var myID = transform.GetComponent<NetworkObject>().NetworkObjectId;
        if (IsServer)
        {
            UserData userData = HostSingleton.Instance.gameManager.networkServer.GetUserDataByClientId(OwnerClientId);
            playerName.Value = userData.userName;
            OnPlayerSpawned?.Invoke(this);
        }




        if (IsOwnedByServer)
            transform.name = "Host:" + myID;    //this must be the host
        else
            transform.name = "Client:" + myID; //this must be the client 

        if (!IsOwner) return;

            
            GameObject.Find("Network Manager").GetComponent<VivoxPlayer>().SignIntoVivox();
        
        
    }
    public override void OnNetworkDespawn()
    {
        if (IsServer)
        {
            OnPlayerDespawned?.Invoke(this);
        }
    }
}
