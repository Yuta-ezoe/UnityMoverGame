using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[Serializable]
public struct SaveData
{
    public List<string> deck;
    public Vector3[] vector;
    public int money;
}

public static class SaveManager
{

    public static SaveData saveData;
    const string SAVE_FILE_PATH = "save.json";


    public static void SaveVector(Vector3[] _vector)
    {
        saveData.vector = _vector;
        Save();
    }


    public static void SaveDeck(List<string> _deck)
    {
        saveData.deck = _deck;
        Save();
    }

    public static void SaveMoney(int _money)
    {
        saveData.money = _money;
        Save();
    }

    public static void Save()
    {
        string json = JsonUtility.ToJson(saveData);
#if UNITY_EDITOR
        string path = Directory.GetCurrentDirectory();
#else
        string path = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');
#endif
        Debug.Log(path);
        path += ("/" + SAVE_FILE_PATH);
        StreamWriter writer = new StreamWriter(path, false);
        writer.WriteLine(json);
        writer.Flush();
        writer.Close();
    }

    public static void Load()
    {
        try
        {
#if UNITY_EDITOR
            string path = Directory.GetCurrentDirectory();
#else
        string path = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');
#endif
            FileInfo info = new FileInfo(path + "/" + SAVE_FILE_PATH);
            StreamReader reader = new StreamReader(info.OpenRead());
            string json = reader.ReadToEnd();
            saveData = JsonUtility.FromJson<SaveData>(json);
        }
        catch (Exception)
        {
            saveData = new SaveData();
        }
    }
}