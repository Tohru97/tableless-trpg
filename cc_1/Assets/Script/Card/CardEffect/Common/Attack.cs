using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "Card/Common/Attack")]
public class Attack : CardEffect
{
    enum TargetType
    {
        Enemy,
        EnemyPartner,
        EnemyBoth,
    }

    enum PowerType
    {
        PlayerPower,
    }

    [SerializeField]
    private TargetType _targetType;
    
    [SerializeField]
    private PowerType _powerType;

    public override void Execute(CardExecutionContext context)
    {
    }
}
