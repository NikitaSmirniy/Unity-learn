using UnityEngine;
using System.IO;

public class LoaderJson
{
    public void Load<T>(T loadedType)
    {
        string key = $"{nameof(loadedType)}.json";

        string path = Path.Combine(Application.persistentDataPath, key);

        using (StreamReader streamReader = new(path))
        {
            string json = streamReader.ReadToEnd();

            loadedType = JsonUtility.FromJson<T>(json);
            streamReader.Close();
        }
        
        Debug.Log(loadedType);
    }

    private bool HasKeyInDataPath(string key)
    {
        if (File.Exists(Application.persistentDataPath + "/" + key))
            return true;

        return false;
    }
}