using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
using UnityEngine;

public class Serializer<T>
{
    public void Save(T _toSave, string _Filename)
    {
        //file extension -> 
        string path = Path.Combine(Application.persistentDataPath + "\\" + _Filename + ".bin");
        //if (!Directory.Exists(_path))
        //{
        //    //1
        //    Debug.LogError($"MissingDirectory {_path}");
        //    Directory.CreateDirectory(_path);
        //    //2
        //    return;
        //}

        //define type
        IFormatter format = new BinaryFormatter();
        //defing path
        Stream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        format.Serialize(file, _toSave);
        file.Dispose();
    }

    public T Load(string _Filename)
    {
        string path = Path.Combine(Application.persistentDataPath + _Filename + ".bin");
        Stream file = new FileStream(path, FileMode.Open, FileAccess.Read);
        IFormatter format = new BinaryFormatter();
        T read = (T)format.Deserialize(file);
        file.Dispose();
        return read;
    }
}
