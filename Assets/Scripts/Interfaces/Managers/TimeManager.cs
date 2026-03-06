using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    public static TimeManager Instance { get; private set; }

    [SerializeField] private float updateInterval = 5f; // можно настроить в инспекторе

    private List<IUpdatable> updatables = new List<IUpdatable>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        OilCompanyData.RegisterPending(this);
    }

    private void Start()
    {
        StartCoroutine(UpdateRoutine());
        TickAll();
    }

    private IEnumerator UpdateRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(updateInterval);
            TickAll();
        }
    }

    private void TickAll()
    {
        // Создаём копию списка, чтобы не сломаться, если во время Tick какой-то объект удалится
        var list = new List<IUpdatable>(updatables);
        foreach (var updatable in list)
        {
            if (updatable != null)
                updatable.Tick();
        }
    }

    public void Register(IUpdatable obj)
    {
        if (!updatables.Contains(obj))
            updatables.Add(obj);
    }

    public void Unregister(IUpdatable obj)
    {
        updatables.Remove(obj);
    }
}
