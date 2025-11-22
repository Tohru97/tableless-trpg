using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;

public class NetworkController : SingletonMono<NetworkController>, IInitializable
{
    [SerializeField]
    private NetworkManager _networkManager;

    [SerializeField]
    private UnityTransport _unityTransport;

    #region Host Variables
    public bool _isHost {get; private set;} = false;

    public NetPlayer _localPlayer {get; set;}
    public NetPlayer _remotePlayer {get; set;}
    #endregion

    public UniTask InitializeAsync()
    {
        Debug.Log("NetworkController Initialized");

        _unityTransport.ConnectionData.Address = "127.0.0.1";
        _unityTransport.ConnectionData.Port = 7778;

        SetNetworkManagerCallback();

        return UniTask.CompletedTask;
    }

    private void SetNetworkManagerCallback()
    {
        _networkManager.OnServerStarted += () =>
        {
            Debug.Log("Server started.");
        };

        _networkManager.OnServerStopped += (isStop) =>
        {
            Debug.Log("Server stopped.");
        };

        _networkManager.OnClientConnectedCallback += (clientId) =>
        {
            Debug.Log($"Client connected: {clientId}");
        };

        _networkManager.OnClientDisconnectCallback += (clientId) =>
        {
            Debug.Log($"Client disconnected: {clientId}");
        };
    }

    #region Host
    public void StartHost()
    {
        _isHost = true;
        _networkManager.StartHost();
    }

    #endregion

    #region Client
    public void JoinMatch()
    {
        _unityTransport.ConnectionData.Address = "127.0.0.1";
        _unityTransport.ConnectionData.Port = 7778;

        _isHost = false;
        _networkManager.StartClient();
    }
    #endregion
}
