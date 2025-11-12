using Cysharp.Threading.Tasks;
using UnityEngine;

public class PlanningPhase : MatchPhaseBase
{
    public PlanningPhase(MatchControllerBase matchController) : base(matchController)
    {
    }

    public override async UniTaskVoid ExecutePhase()
    {
        Debug.Log("===== PlanningPhase Start =====");
        Debug.Log("Waiting for both players to end their turn...");
        // TODO: 양쪽 플레이어가 카드 선택 및 순서 지정을 완료하고
        // '결정 완료' 버튼을 누를 때까지 대기하는 로직.
        // 이 페이즈는 OnPlayerTurnEnded가 양쪽 모두 호출되면 종료됩니다.
        // 현재는 자동 종료.
        await UniTask.Delay(500);

        // 실제 구현에서는 OnPlayerTurnEnded 호출 시 RequestPhaseEnd가 호출되므로
        // 아래 코드는 필요 없을 수 있습니다.
        // Debug.Log("===== PlanningPhase End =====");
        // RequestPhaseEnd();
    }
}
