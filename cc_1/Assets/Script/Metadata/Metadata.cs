using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public static class Metadata
{
    public static CharacterData _characterData;

    public static async UniTask Init()
    {
        _characterData = new CharacterData();

        _characterData.ClearDatas();

        TextAsset characterData = await AddressableManager.Instance.LoadAssetAsync<TextAsset>("CharacterData");
        _characterData.Parsing(CSVTool.GetDecryptData(characterData.bytes));
    }
}