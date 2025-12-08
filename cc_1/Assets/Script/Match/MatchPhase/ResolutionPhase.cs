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

        // Get play card result from network or local logic

        await UniTask.Delay(500); // 임시 딜레이

        Debug.Log("===== ResolutionPhase End =====");
        RequestPhaseEnd();
    }
}