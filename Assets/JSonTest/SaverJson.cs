using UnityEngine;
using System.IO;

public class SaverJson
{
    public void Save<T>(T savedType)
    {
        string json = JsonUtility.ToJson(savedType);

        string key = $"{nameof(savedType)}.json";

        string path = Path.Combine(Application.persistentDataPath, key);

        using (StreamWriter writer = new(path))
        {
            writer.WriteLine(json);
        }

        Debug.Log("Save");
    }
}