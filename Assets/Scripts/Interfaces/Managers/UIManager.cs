using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private GameObject notificationPrefab;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        // DontDestroyOnLoad(gameObject); // если нужно
    }

    public void ShowNotification(string text)
    {
        if (notificationPrefab == null) return;
        var notif = Instantiate(notificationPrefab, transform);
        //notif.GetComponent<NotificationView>().SetText(text);
        Destroy(notif, 2f);
    }

}
