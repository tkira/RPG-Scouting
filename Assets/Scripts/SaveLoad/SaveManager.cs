using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager
{
    public PlayerStats playerstats;


    public static void Save(CharacterStats characterStats)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = File.Open(Application.persistentDataPath + "/test.dat", FileMode.OpenOrCreate);
        PlayerStats stats = new PlayerStats(characterStats);
        formatter.Serialize(stream, stats);
        stream.Close();
    }

    public static PlayerStats Load()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = File.Open(Application.persistentDataPath + "/test.dat", FileMode.Open);
        PlayerStats stats = (PlayerStats)formatter.Deserialize(stream);
        stream.Close();
        return stats;

    }

}
