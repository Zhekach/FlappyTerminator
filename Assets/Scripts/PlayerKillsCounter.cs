using UnityEngine;

public class PlayerKillsCounter : MonoBehaviour
{
    public int Kills{get; private set;} = 0;

    public void Add()
    {
        Kills++;
    }
    
    public void Reset()
    {
        Kills = 0;
    }
}