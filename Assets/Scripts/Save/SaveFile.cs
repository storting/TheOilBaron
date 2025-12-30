using System;
using System.Collections.Generic;

[Serializable]
public struct SaveFile
{
    public DateTime SaveTime { get; }
    public List<SaveLoadData> Data { get; }
    public SaveFile(List<SaveLoadData> data) : this()
    {
        Data = data; 
        SaveTime = DateTime.Now;
    }
}
