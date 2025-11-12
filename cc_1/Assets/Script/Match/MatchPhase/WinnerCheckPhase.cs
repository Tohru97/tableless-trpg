using Cysharp.Threading.Tasks;
using UnityEngine;

public class WinnerCheckPhase : MatchPhaseBase
{
    public bool IsGameFinished { get; private set; }

    public WinnerCheckPhase(MatchControllerBase matchController) : base(matchController)
    {
    }

    public override async UniTaskVoid ExecutePhase()
    {
        Debug.Log("===== WinnerCheckPhase Start =====");
        // TODO: 플레이어 HP 등을 확인하여 게임 종료 조건 체크
        // IsGameFinished = ...

        await UniTask.Delay(500); // 임시 딜레이

        Debug.Log("===== WinnerCheckPhase End =====");
        RequestPhaseEnd();
    }
}
