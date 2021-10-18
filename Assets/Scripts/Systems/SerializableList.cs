using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class SerializableList<T> : IEnumerable
{

    public T this[int index] { get {return innerArray[index];} set {innerArray[index] = value;} }
    public int Count {get {return innerArray.Length;}}
    
    [SerializeField]
    private T[] innerArray;
    public SerializableList()
    {
        innerArray = new T[0];
    }

    public List<T> ToList()
    {
        return innerArray.ToList();
    }

    public static implicit operator List<T>(SerializableList<T> list) => list.ToList();

    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator) GetEnumerator();
    }

    public GenEnum<T> GetEnumerator()
    {
        return new GenEnum<T>(innerArray);
    }

    public void Add(T obj)
    {
        T[] newArray = new T[innerArray.Length + 1];
        innerArray.CopyTo(newArray, 0);
        newArray[innerArray.Length] = obj;
        innerArray = newArray;
    }
}

public class GenEnum<T> : IEnumerator
{
    public T[] _objects;
    int position = -1;

    public GenEnum(T[] list)
    {
        _objects = list;
    }

    public bool MoveNext()
    {
        position++;
        return (position < _objects.Length);
    }

    public void Reset()
    {
        position = -1;
    }

    object IEnumerator.Current
    {
        get {return Current;}
    }

    public object Current
    {
        get
        {
            try
            {
                return _objects[position];
            }
            catch (System.IndexOutOfRangeException)
            {
                throw new System.InvalidOperationException();
            }
        }
    }
}
