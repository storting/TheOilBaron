using UnityEngine;



public class Saver : MonoBehaviour
{
    [SerializeField] private Player _player;

    private SaveLoadSystem _saveLoadSystem;

    private void Start()
    {
        _saveLoadSystem ??= new();
        _saveLoadSystem.AddToSaveLoad(_player);
    }


    private void Save()
    {
        _saveLoadSystem.SaveGame(SaveType.File);
    }


    private void Load()
    {
        _saveLoadSystem.LoadGame(SaveType.File);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            Save();

        if (Input.GetKeyDown(KeyCode.L))
            Load();
    }
}
