using System;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadSystem
{
    private readonly FileSaveLoadStrategy _fileSaveLoadStrategy = new();

    private Dictionary<string, ISaveLoadObject> _componentsIdToSaveObject = new();

    public void AddToSaveLoad(ISaveLoadObject saveLoadObject)
    => _componentsIdToSaveObject[saveLoadObject.ComponentSaveId] = saveLoadObject;

    public void SaveGame(SaveType saveType)
    {
        var strategy = saveType switch
        {
            SaveType.File => _fileSaveLoadStrategy,
            _ => throw new NotImplementedException()
        };

        SaveAll(strategy);
    }

    public void LoadGame(SaveType saveType)
    {
        var strategy = saveType switch
        {
            SaveType.File => _fileSaveLoadStrategy,
            _ => throw new NotImplementedException()
        };

        Load(strategy);
    }

    private void SaveAll(ISaveLoadStrategy strategy) => Save(strategy, _componentsIdToSaveObject.Values);

    private void Save(ISaveLoadStrategy strategy, IEnumerable<ISaveLoadObject> data) => strategy.Save(data);

    private void Load(ISaveLoadStrategy strategy)
    {
        var loadedData = strategy.Load();

        foreach (var data in loadedData)
        {
            var objectId = data.Id;
            if (!_componentsIdToSaveObject.ContainsKey(objectId))
            {
                Debug.LogError($"Cant restore data for object with id {objectId}");
                continue;
            }

            _componentsIdToSaveObject[objectId].RestoreValues(data);
        }
    }
}
