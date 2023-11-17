using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkServer : IDisposable
{
    private NetworkManager networkManager;
    public Action<string> OnClientLeft;

    private Dictionary<ulong, string> clientIdToAuth = new Dictionary<ulong, string>();

    private Dictionary<string, UserData> authIdToUseData = new Dictionary<string, UserData>();
   public NetworkServer(NetworkManager networkManager)
    {
        this.networkManager = networkManager;

        networkManager.ConnectionApprovalCallback += ApprovalCheck;

        networkManager.OnServerStarted += OnNetworkReady;
    }

    

    private void ApprovalCheck
        (NetworkManager.ConnectionApprovalRequest request, NetworkManager.ConnectionApprovalResponse response)
    {
        string payload= System.Text.Encoding.UTF8.GetString(request.Payload);
        UserData userData=JsonUtility.FromJson<UserData>(payload);

        clientIdToAuth[request.ClientNetworkId] = userData.userAuthId;
        authIdToUseData[userData.userAuthId] = userData;

        response.Approved = true;
        response.Rotation = Quaternion.identity;
        response.CreatePlayerObject = true;
    }

    private void OnNetworkReady()
    {
        networkManager.OnClientDisconnectCallback += OnClientDisconnect;

       
    }

    private void OnClientDisconnect(ulong clientId)
    {
        if (clientIdToAuth.TryGetValue(clientId, out string authId))
        {
            clientIdToAuth.Remove(clientId);
            authIdToUseData.Remove(authId);
            OnClientLeft?.Invoke(authId);
        }
    }
    public UserData GetUserDataByClientId(ulong clientId)
    {
        if (clientIdToAuth.TryGetValue(clientId,out string authId))
        {
            if (authIdToUseData.TryGetValue(authId,out UserData data))
            {
                Debug.Log("1111111111111111111111111111111111111111111111");
                return data;
            }
            Debug.Log("2222222222222222222222222222222222222222222222222222");

            return null;
        }
        Debug.Log("33333333333333333333333333333333333333333333333333333333333333222");

        return null;
    }
    public void Dispose()
    {
        if (networkManager!=null)
        { return;  }

        networkManager.ConnectionApprovalCallback -= ApprovalCheck;
        networkManager.OnClientDisconnectCallback -= OnClientDisconnect;
        networkManager.OnServerStarted -= OnNetworkReady;

        if (networkManager.IsListening)
        {
            networkManager.Shutdown();
        }
    }
}
