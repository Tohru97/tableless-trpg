using Cysharp.Threading.Tasks;
using UnityEngine;

public class DrawCardPhase : MatchPhaseBase
{
    public DrawCardPhase(MatchControllerBase matchController) : base(matchController)
    {
    }

    public override async UniTaskVoid ExecutePhase()
    {
        RequestPhaseEnd();
    }
}
