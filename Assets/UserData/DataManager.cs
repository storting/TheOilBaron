using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [Header("Настройки сохранения")]
    private static readonly string SECRET_KEY = "RUSSIA2025vladArtem";
    private static readonly string SAVE_FOLDER = "UserData/UserStats";
    private static readonly string FILE_EXTENSION = ".dat";

    public static void SaveData(object data, string saveName)
    {
        try
        {
            // 1. Создаем папку если нужно
            string saveDir = GetSaveDirectory();
            if (!Directory.Exists(saveDir))
                Directory.CreateDirectory(saveDir);

            // 2. Преобразуем объект в JSON
            string jsonData = JsonUtility.ToJson(data, true);

            // 3. Шифруем данные
            string encryptedData = EncryptData(jsonData);

            // 4. Сохраняем в файл
            string filePath = GetFilePath(saveName);
            File.WriteAllText(filePath, encryptedData);

            Debug.Log($"Данные сохранены: {filePath}");
        }
        catch (Exception e)
        {
            Debug.LogError($"Ошибка сохранения: {e.Message}");
        }

        /***UserBaseData
        PlayerPrefs.SetInt("MoneyUser", main.MoneyCount);
        PlayerPrefs.SetInt("OilUser", main.OilCount);
        PlayerPrefs.SetInt("TapScale", main.TapScale);
        PlayerPrefs.SetInt("UserLevel", main.UserLevelCompany);
        PlayerPrefs.SetInt("Charisma", main.Charisma);
        PlayerPrefs.SetInt("Erudition", main.Erudition);
        PlayerPrefs.SetInt("Intelligence", main.Intelligence);
        PlayerPrefs.SetInt("Eloquence", main.Eloquence);
        PlayerPrefs.Save();***/
    }

    public static T LoadData<T>(string saveName) where T : new()
    {

        try
        {
            string filePath = GetFilePath(saveName);

            // Проверяем существует ли файл
            if (!File.Exists(filePath))
            {
                Debug.LogWarning($"попытка загрузки - Файл не найден: {filePath}");
                return new T(); // Возвращаем новый объект
            }

            // Читаем и расшифровываем данные
            string encryptedData = File.ReadAllText(filePath);
            string jsonData = DecryptData(encryptedData);

            // Преобразуем JSON в объект
            return JsonUtility.FromJson<T>(jsonData);
        }
        catch (Exception e)
        {
            Debug.LogError($"Ошибка загрузки: {e.Message}");
            return new T(); // Возвращаем новый объект при ошибке
        }

        /***UserBaseData
        if (PlayerPrefs.HasKey("MoneyUser")) main.MoneyCount = PlayerPrefs.GetInt("MoneyUser");
        if (PlayerPrefs.HasKey("OilUser")) main.OilCount = PlayerPrefs.GetInt("OilUser");
        if (PlayerPrefs.HasKey("TapScale")) main.TapScale = PlayerPrefs.GetInt("TapScale");
        if (PlayerPrefs.HasKey("UserLevel")) main.UserLevelCompany = PlayerPrefs.GetInt("UserLevel");
        if (PlayerPrefs.HasKey("Charisma")) main.Charisma = PlayerPrefs.GetInt("Charisma");
        if (PlayerPrefs.HasKey("Erudition")) main.Erudition = PlayerPrefs.GetInt("Erudition");
        if (PlayerPrefs.HasKey("Intelligence")) main.Intelligence = PlayerPrefs.GetInt("Intelligence");
        if (PlayerPrefs.HasKey("Eloquence")) main.Eloquence = PlayerPrefs.GetInt("Eloquence");
        Debug.Log("DataLoad");
        ***/
    }

    private static string GetSaveDirectory()
    {
        return Path.Combine(Application.persistentDataPath, SAVE_FOLDER);
    }

    private static string GetFilePath(string saveName)
    {
        return Path.Combine(GetSaveDirectory(), saveName);
    }


    private static string EncryptData(string plainText)
    {
        // Base64 кодирование
        string base64Data = Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));

        // Простое "перемешивание" с ключом
        return ScrambleString(base64Data, SECRET_KEY);
    }

    private static string DecryptData(string encryptedText)
    {
        // "Размешивание" данных
        string base64Data = UnscrambleString(encryptedText, SECRET_KEY);

        // Base64 декодирование
        byte[] bytes = Convert.FromBase64String(base64Data);
        return Encoding.UTF8.GetString(bytes);
    }
    private static string ScrambleString(string input, string key)
    {
        char[] chars = input.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            chars[i] = (char)(chars[i] ^ key[i % key.Length]); // Используем XOR
        }
        return new string(chars);
    }

    private static string UnscrambleString(string input, string key)
    {
        // XOR обратим - тот же метод что и для шифрования
        return ScrambleString(input, key);
    }

    // Удалить файл сохранения
    public void DeleteSave()
    {
        string filePath = Path.Combine(Application.persistentDataPath, FILE_EXTENSION);
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Debug.Log("Сохранение удалено");
        }
    }
}
