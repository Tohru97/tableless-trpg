using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    public int _characterIndex;
    public string _characterName;
    public int _baseHP;
    public int _basePower;
    
    public CharacterBase(int characterIndex, string characterName, int baseHP, int basePower)
    {
        _characterIndex = characterIndex;
    }
}