using UnityEngine;

public class PveMatchController : MatchControllerBase
{
    private int _currentTurn;

    public override void SetMatchPhases()
    {
        DistributeCharactersPhase distributeCharactersPhase = new DistributeCharactersPhase(this);
        DraftPickPhase draftPickPhase1 = new DraftPickPhase(this);
        CharacterSwapPhase characterSwapPhase = new CharacterSwapPhase(this);
        DraftPickPhase draftPickPhase2 = new DraftPickPhase(this);

        DrawPhase drawPhase = new DrawPhase(this);
        PreRevealPhase preRevealPhase = new PreRevealPhase(this);
        PlanningPhase planningPhase = new PlanningPhase(this);
        ResolutionPhase resolutionPhase = new ResolutionPhase(this);        // process combat logic
        WinnerCheckPhase winnerCheckPhase = new WinnerCheckPhase(this);

        distributeCharactersPhase.OnRequestNextPhase = draftPickPhase1.StartPhase;
        draftPickPhase1.OnRequestNextPhase = characterSwapPhase.StartPhase;
        characterSwapPhase.OnRequestNextPhase = draftPickPhase2.StartPhase;
        draftPickPhase2.OnRequestNextPhase = drawPhase.StartPhase;
        drawPhase.OnRequestNextPhase = preRevealPhase.StartPhase;
        preRevealPhase.OnRequestNextPhase = planningPhase.StartPhase;
        planningPhase.OnRequestNextPhase = resolutionPhase.StartPhase;
        resolutionPhase.OnRequestNextPhase = winnerCheckPhase.StartPhase;
        winnerCheckPhase.OnRequestNextPhase = drawPhase.StartPhase;

        _currentPhase = distributeCharactersPhase;
    }
}