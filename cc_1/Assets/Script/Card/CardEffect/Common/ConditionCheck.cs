using UnityEngine;

[CreateAssetMenu(menuName = "Card/CardEffect/ConditionCheck")]
public class ConditionCheck : CardEffect
{
    enum ConditionType
    {
        None,
        Success,
        Failure,
    }

    [SerializeField]
    private ConditionType _conditionType;

    public override void ApplyEffect()
    {
        throw new System.NotImplementedException();
    }
}
