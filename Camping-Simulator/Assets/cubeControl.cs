using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class cubeControl : NetworkBehaviour
{
    GameObject cube;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DestroyCubeServerRpc();
        }
    }

    [ServerRpc]
    public void DestroyCubeServerRpc()
    {
        cube = GameObject.FindWithTag("Cube");
        Destroy(cube);
        DestroyCubeClientRpc();
    }
    [ClientRpc]
    public void DestroyCubeClientRpc()
    {
        Destroy(cube);
    }
}
