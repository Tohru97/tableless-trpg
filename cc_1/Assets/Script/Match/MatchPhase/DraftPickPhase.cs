using Cysharp.Threading.Tasks;
using UnityEngine;

public class DraftPickPhase : MatchPhaseBase
{
    public DraftPickPhase(MatchControllerBase matchController) : base(matchController)
    {
    }

    public override async UniTaskVoid ExecutePhase()
    {
        Debug.Log("===== DraftPickPhase Start =====");
        // TODO: 플레이어가 캐릭터를 선택하기를 대기.
        // OnCharacterSelected 이벤트가 호출되어 조건이 만족될 때까지 기다립니다.

        _matchController.StartTurnEndTimer(30f);

        await UniTask.Delay(500); // 임시 딜레이

        Debug.Log("===== DraftPickPhase End =====");
        RequestPhaseEnd();
    }
}