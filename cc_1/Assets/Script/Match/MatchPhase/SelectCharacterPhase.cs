using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SelectCharacterPhase : MatchPhaseBase
{
    private float _characterSelectTime = 10f;

    public SelectCharacterPhase(MatchControllerBase matchController) : base(matchController)
    {
    }

    public override async UniTaskVoid ExecutePhase()
    {
        // Request character list

        // Wait for both players to select characters

        // Send selected character info to server

        // Swap character List

        // Send character list

        // Wait for both players to select characters

        // set selected characters

        await UniTask.WaitUntil(() => _matchController._localCharacterDict.Count == 1 && _matchController._remoteCharacterDict.Count == 1);

        await UniTask.WaitUntil(() => _matchController._localCharacterDict.Count == 2 && _matchController._remoteCharacterDict.Count == 2);

        RequestPhaseEnd();
    }
}