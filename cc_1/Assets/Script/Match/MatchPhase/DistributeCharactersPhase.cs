using Cysharp.Threading.Tasks;
using UnityEngine;

public class DistributeCharactersPhase : MatchPhaseBase
{
    public DistributeCharactersPhase(MatchControllerBase matchController) : base(matchController)
    {
    }

    public override async UniTaskVoid ExecutePhase()
    {
        Debug.Log("===== DistributeCharactersPhase Start =====");
        // TODO: 플레이어들에게 선택 가능한 캐릭터 리스트를 보여주는 로직 구현

        await UniTask.Delay(500); // 임시 딜레이
        
        Debug.Log("===== DistributeCharactersPhase End =====");
        RequestPhaseEnd();
    }
}
