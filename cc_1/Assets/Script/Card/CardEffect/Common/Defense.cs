using UnityEngine;

[CreateAssetMenu(fileName = "Defense", menuName = "Card/Common/Defense")]
public class Defense : CardEffect
{
    enum DefenseType
    {
        Target,
        Both,
    }

    [SerializeField]
    private DefenseType _defenseType;

    public override void Execute(CardExecutionContext context)
    {
    }
}
