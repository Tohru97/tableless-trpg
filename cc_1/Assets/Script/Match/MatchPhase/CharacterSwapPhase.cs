using Cysharp.Threading.Tasks;
using UnityEngine;

public class CharacterSwapPhase : MatchPhaseBase
{
    public CharacterSwapPhase(MatchControllerBase matchController) : base(matchController)
    {
    }

    public override async UniTaskVoid ExecutePhase()
    {
        Debug.Log("===== CharacterSwapPhase Start =====");
        // TODO: 캐릭터 스왑 로직 구현

        await UniTask.Delay(500); // 임시 딜레이

        Debug.Log("===== CharacterSwapPhase End =====");
        RequestPhaseEnd();
    }
}
