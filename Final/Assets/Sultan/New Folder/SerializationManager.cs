using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SerializationManager 
{
    public static void Save(LevelGoing levelGoing, FPS_first_level fps)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/levelState.fun";

        File.Create(path).Dispose();
        FileStream stream = new FileStream(path, FileMode.Create);
        

        LevelState data = new LevelState(levelGoing, fps);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static LevelState Load()
    {
        string path = Application.persistentDataPath + "/levelState.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            LevelState data;

            if (stream.Length == 0)
            {
                data = formatter.Deserialize(stream) as LevelState;
                stream.Close();

                return data;

            }
            
            stream.Close();

            return null;
        }
        else
        {
            Debug.LogError("Net");
            return null;
        }
    }


    
}
