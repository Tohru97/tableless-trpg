using System.Collections.Generic;
using UnityEngine;

public class CharacterData : BaseData
{
    public class Data : Key
    {
        public int id {get;private set;}
        public string character_name {get; private set;}
        public string character_desc {get; private set;}
        public int character_base_hp {get; private set;}
        public int character_base_power {get; private set;}

        public Data(int key, string character_name, string character_desc, int character_base_hp, int character_base_power) : base(key)
        {
            this.id = key;
            this.character_name = character_name;
            this.character_desc = character_desc;
            this.character_base_hp = character_base_hp;
            this.character_base_power = character_base_power;
        }
    }

    private Dictionary<int, Data> dataDic = new Dictionary<int, Data>();

    public Data GetData(int key)
    {
        if (dataDic.TryGetValue(key, out Data data))
            return data;

        return null;
    }

    public override void ClearDatas()
    {
        dataDic.Clear();
    }

    public override bool Parsing(List<Dictionary<string, string>> datas)
    {
        for(int i=1; i<datas.Count; i++)    // index == 0 <- column
        {
            Data newData = new Data
            (
                key: ParseInt(datas[i]["id"]),
                character_name: ParseString(datas[i]["character_name"]),
                character_desc: ParseString(datas[i]["character_desc"]),
                character_base_hp: ParseInt(datas[i]["character_base_hp"]),
                character_base_power: ParseInt(datas[i]["character_base_power"])
            );

            dataDic.Add(newData.id, newData);
        }

        return true;
    }
}
