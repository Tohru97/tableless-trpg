using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/Card")]
public class Card : ScriptableObject
{
    private CharacterBase _ownerCharacter;

    [SerializeField]
    private int _cardIndex;

    private string _cardName, _cardDesc;

    private bool _isStartCard;

    [SerializeField]
    private List<CardEffect> _mainCardEffects;

    [SerializeField]
    private EffectActivationCondition _effectActivationCondition;

    [SerializeField]
    private List<CardEffect> _additionalCardEffects;

    public Card(CharacterBase ownerCharacter, bool isStartCard)
    {
        _ownerCharacter = ownerCharacter;
        _isStartCard = isStartCard;
    }
}

public class CardExecutionContext
{
    public CardEffect _previousEffect {get; private set;}

    public CardExecutionContext(CardEffect previousEffect)
    {
        _previousEffect = previousEffect;
    }
}

public enum EffectActivationCondition
{
    None = 0,
    Success = 1,
    Failure = 2,
    DamageTaken = 3,
    DamageBlocked = 4,
    
}