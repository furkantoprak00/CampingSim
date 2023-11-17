using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using Unity.Netcode;
using UnityEngine;

public class CanvaLauncher : NetworkBehaviour

{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject serverPrefab;
    [SerializeField] private GameObject clientPrefab;
    private bool deneme=true;

    private void Update()
    {
        spawnPoint = GameObject.Find("VideoPoint").GetComponent<Transform>();
       
        
    }
    public override void OnNetworkSpawn()
    {
        if (!IsOwner) { return; }
       
    }

    public void Spawn()
    {

            if (deneme)
            {
                if (!IsOwner)
                {
                    return;
                }
                PrimaryCanvaServerRpc(spawnPoint.position);
               // SpawnDummyProjectile(spawnPoint.position);
                deneme = false;
            }

      
    }
    [ServerRpc]
    private void PrimaryCanvaServerRpc(UnityEngine.Vector3 position)
    {
        GameObject projectileInstance = Instantiate(serverPrefab, position, quaternion.identity);
        SpawnDUmmyCanvaClientRpc(position);
    }
    [ClientRpc]
    private void SpawnDUmmyCanvaClientRpc(UnityEngine.Vector3 position)
    {
        if (IsOwner)
        {
            return;
        }
        SpawnDummyProjectile(position);
    }
    private void SpawnDummyProjectile(UnityEngine.Vector3 position)
    {
        GameObject projectileInstance = Instantiate(clientPrefab,position,quaternion.identity);
    }
}
