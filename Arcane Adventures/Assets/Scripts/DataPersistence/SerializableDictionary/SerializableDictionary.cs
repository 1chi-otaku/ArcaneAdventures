using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableDictionary<Tkey, Tvalue> : Dictionary<Tkey, Tvalue>, ISerializationCallbackReceiver
{

    [SerializeField] private List<Tkey> tkeys = new List<Tkey>();
    [SerializeField] private List<Tvalue> values = new List<Tvalue>();
    public void OnAfterDeserialize()
    {
        this.Clear();

        for (int i = 0; i < tkeys.Count; i++)
        {
            this.Add(tkeys[i], values[i]);
        }
    }

    public void OnBeforeSerialize()
    {
        tkeys.Clear();
        values.Clear();
        foreach (KeyValuePair<Tkey, Tvalue> pair in this)
        {
            tkeys.Add(pair.Key);
            values.Add(pair.Value);
        }
    }
}