using Cysharp.Threading.Tasks;
using UnityEngine;

public class MatchEndPhase : MatchPhaseBase
{
    public MatchEndPhase(MatchControllerBase matchController) : base(matchController)
    {
    }

    public override async UniTaskVoid ExecutePhase()
    {
        Debug.Log("===== MatchEndPhase Start =====");
        // TODO: 승/패 결과 UI 표시, 보상 처리 등

        await UniTask.Delay(500); // 임시 딜레이
    }
}
