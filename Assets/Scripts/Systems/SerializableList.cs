using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableList<T>
{

    public T this[int index] { get {return innerList[index];} set {innerList.Add(value);} }
    public int Count {get {return innerList.Count;}}
    
    [SerializeField]
    private List<T> innerList;
    public SerializableList()
    {
        innerList = new List<T>();
    }

    public List<T> ToList()
    {
        return innerList;
    }

    public static implicit operator List<T>(SerializableList<T> list) => list.ToList();
}
