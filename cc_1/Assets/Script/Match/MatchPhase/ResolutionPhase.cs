using Cysharp.Threading.Tasks;
using UnityEngine;

public class ResolutionPhase : MatchPhaseBase
{
    public ResolutionPhase(MatchControllerBase matchController) : base(matchController)
    {
    }

    public override async UniTaskVoid ExecutePhase()
    {
        Debug.Log("===== ResolutionPhase Start =====");
        // TODO: 카드 순서에 따라 아래 로직 반복
        // 1. 카드 공개 (CardReveal)
        // 2. 우선권 체크 (PriorityCheck)
        // 3. 효과 발동 (EffectExecution)

        await UniTask.Delay(500); // 임시 딜레이

        Debug.Log("===== ResolutionPhase End =====");
        RequestPhaseEnd();
    }
}
