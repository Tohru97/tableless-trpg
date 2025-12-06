using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    protected int _characterIndex;
    protected string _characterName;
    protected int _baseHP;
    protected int _basePower;

    public int _currentHp { get; private set; }
    public int _currentPower { get; private set; }

    public virtual void Init(int characterIndex)
    {
        _characterIndex = characterIndex;

        CharacterData.Data data = Metadata._characterData.GetData(characterIndex);

        _characterName = data.character_name;
        _baseHP = data.character_base_hp;
        _basePower = data.character_base_power;

        _currentHp = _baseHP;
        _currentPower = _basePower;
    }

    public void ChangeCurrentHP(int hp)
    {
        _currentHp += hp;
    }

    public void ChangeCurrentPower(int power)
    {
        _currentPower += power;
    }
}