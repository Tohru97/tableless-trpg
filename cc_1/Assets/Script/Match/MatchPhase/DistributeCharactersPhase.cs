using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class DistributeCharactersPhase : MatchPhaseBase
{
    public DistributeCharactersPhase(MatchControllerBase matchController) : base(matchController)
    {
    }

    public override async UniTaskVoid ExecutePhase()
    {
        Debug.Log("===== DistributeCharactersPhase Start =====");
        // TODO: 플레이어들에게 선택 가능한 캐릭터 리스트를 보여주는 로직 구현

        // Get Character List From Server

        // Show Character Selection UI to Players

        // Wait Player Select Character

        // If Pvp, Wait Both Players Select Character

        await UniTask.Delay(500); // 임시 딜레이
        
        Debug.Log("===== DistributeCharactersPhase End =====");
        RequestPhaseEnd();
    }
}
