using System.Linq;
using UnityEngine;

public class GamePersist : MonoBehaviour
{

    // void OnDisable() => Save();

    // void OnEnable() => Load();

    public void Load()
    {
        foreach (var persist in FindObjectsOfType<MonoBehaviour>(true).OfType<ISaveState>())

        {
            persist.Load();
        }
    }

    public void Save()
    {
        foreach (var persist in FindObjectsOfType<MonoBehaviour>(true).OfType<ISaveState>())
        {
            persist.Save();
        }
    }


}