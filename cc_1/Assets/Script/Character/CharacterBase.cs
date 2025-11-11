using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    public int _characterIndex;
    public string _characterName;
    public int _hp;
    public int _power;
    
    public CharacterBase(int characterIndex)
    {
        _characterIndex = characterIndex;
    }
}