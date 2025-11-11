using Cysharp.Threading.Tasks;
using UnityEngine;

public class CardRevealPhase : MatchPhaseBase
{
    public CardRevealPhase(MatchControllerBase matchController) : base(matchController)
    {
    }

    public override async UniTaskVoid ExecutePhase()
    {
        RequestPhaseEnd();
    }
}
