using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Services.Lobbies.Models;
using UnityEngine;

public class LobbyItem : MonoBehaviour
{
    [SerializeField] private TMP_Text lobbynameText;
    [SerializeField] private TMP_Text lobbyPlayersText;
 

    private LobbiesList lobbiesList;
    private Lobby lobby;
    public void Initialise(LobbiesList lobbiesList,Lobby lobby)
    {
        
        this.lobbiesList = lobbiesList;
        this.lobby = lobby;
        lobbynameText.text = lobby.Name;
        lobbyPlayersText.text = $"{lobby.Players.Count}/{lobby.MaxPlayers}";
    }
    public void Join()
    {
        lobbiesList.JoinAsync(lobby);
    }
}
