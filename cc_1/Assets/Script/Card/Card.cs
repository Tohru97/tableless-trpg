using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/Card")]
public class Card : ScriptableObject
{
    [SerializeField]
    private int _cardIndex;

    private string _cardName, _cardDesc;

    [SerializeField]
    private List<CardEffect> _cardEffects = new List<CardEffect>();
}
