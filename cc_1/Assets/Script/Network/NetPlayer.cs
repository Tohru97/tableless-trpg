using Unity.Netcode;
using UnityEngine;

public class NetPlayer : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        if (IsLocalPlayer)
        {
            NetworkController.Instance._localPlayer = this;

            Debug.Log("Local Player Set");
        }
        else
        {
            NetworkController.Instance._remotePlayer = this;

            Debug.Log("Remote Player Set");
        }

        base.OnNetworkSpawn();
    }

    public override void OnNetworkDespawn()
    {
        if (IsLocalPlayer)
        {
            NetworkController.Instance._localPlayer = null;
        }
        else
        {
            NetworkController.Instance._remotePlayer = null;
        }

        base.OnNetworkDespawn();
    }

    [ServerRpc]
    public void TestServerRpc()
    {
        Debug.Log("Server RPC Called");
    }

    [ServerRpc]
    public void RequestTurnEndedServerRpc(bool isTurnEnded)
    {
        Debug.Log("Server Request Receive");

        ResponseTurnEndedClientRpc(OwnerClientId, isTurnEnded);
    }

    [ClientRpc]
    public void ResponseTurnEndedClientRpc(ulong clientID, bool isTurnEnded)
    {
        if(clientID == OwnerClientId)
        {
            MatchManager.Instance._matchController.ResponseTurnEnded(true, isTurnEnded);
        }
        else
        {
            MatchManager.Instance._matchController.ResponseTurnEnded(false, isTurnEnded);
        }

        Debug.Log($"NetID: {clientID} isTurnEnded: {isTurnEnded}");
    }
}
