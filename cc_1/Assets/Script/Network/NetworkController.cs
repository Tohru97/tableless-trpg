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

    private bool _isHost = false;

    public UniTask InitializeAsync()
    {
        Debug.Log("NetworkController Initialized");
        return UniTask.CompletedTask;
    }

    #region Host
    public void StartHost()
    {
        _isHost = true;
    }
    #endregion

    #region Client
    public void JoinMatch()
    {

    }
    #endregion

    #region Common
    public void RequestTurnEnd()
    {
        
    }
    #endregion
}
