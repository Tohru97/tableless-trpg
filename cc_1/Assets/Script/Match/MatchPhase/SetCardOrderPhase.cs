using Cysharp.Threading.Tasks;
using UnityEngine;

public class SetCardOrderPhase : MatchPhaseBase
{
    public SetCardOrderPhase(MatchControllerBase matchController) : base(matchController)
    {
    }

    public override async UniTaskVoid ExecutePhase()
    {
        RequestPhaseEnd();
    }
}
