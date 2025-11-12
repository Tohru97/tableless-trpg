using Cysharp.Threading.Tasks;
using UnityEngine;

public class PreRevealPhase : MatchPhaseBase
{
    public PreRevealPhase(MatchControllerBase matchController) : base(matchController)
    {
    }

    public override async UniTaskVoid ExecutePhase()
    {
        Debug.Log("===== PreRevealPhase Start =====");
        // TODO: 전투 시작 전 발동하는 카드 효과가 있는지 확인 및 처리

        await UniTask.Delay(500); // 임시 딜레이

        Debug.Log("===== PreRevealPhase End =====");
        RequestPhaseEnd();
    }
}
