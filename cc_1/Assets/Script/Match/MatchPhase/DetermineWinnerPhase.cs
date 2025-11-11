using Cysharp.Threading.Tasks;
using UnityEngine;

public class DetermineWinnerPhase : MatchPhaseBase
{
    public DetermineWinnerPhase(MatchControllerBase matchController) : base(matchController)
    {
    }

    public override async UniTaskVoid ExecutePhase()
    {
        RequestPhaseEnd();
    }
}
