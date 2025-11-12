using Cysharp.Threading.Tasks;
using UnityEngine;

public class DrawPhase : MatchPhaseBase
{
    public DrawPhase(MatchControllerBase matchController) : base(matchController)
    {
    }

    public override async UniTaskVoid ExecutePhase()
    {
        Debug.Log("===== DrawPhase Start =====");
        // TODO: 각 플레이어가 카드를 드로우하는 로직 구현
        // 첫 턴일 경우 고정된 카드를 지급하는 규칙 처리

        await UniTask.Delay(500); // 임시 딜레이

        Debug.Log("===== DrawPhase End =====");
        RequestPhaseEnd();
    }
}
