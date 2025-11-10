using UnityEngine;

public class PveMatchController : MatchControllerBase
{
    private int _currentTurn;

    public override void SetMatchPhases()
    {
        SelectCharacterPhase selectCharacterPhase = new SelectCharacterPhase(this);
        DrawCardPhase drawCardPhase = new DrawCardPhase(this);
        SetCardOrderPhase setCardOrderPhase = new SetCardOrderPhase(this);
        CardRevealPhase cardRevealPhase = new CardRevealPhase(this);
        DetermineWinnerPhase determineWinnerPhase = new DetermineWinnerPhase(this);

        selectCharacterPhase.OnRequestNextPhase = drawCardPhase.StartPhase;
        drawCardPhase.OnRequestNextPhase = setCardOrderPhase.StartPhase;
        setCardOrderPhase.OnRequestNextPhase = cardRevealPhase.StartPhase;
        cardRevealPhase.OnRequestNextPhase = determineWinnerPhase.StartPhase;
        determineWinnerPhase.OnRequestNextPhase = drawCardPhase.StartPhase;

        _currentPhase = selectCharacterPhase;
    }

    public override void RequestTurnEnd()
    {
        _currentPhase.RequestPhaseEnd();
    }
}