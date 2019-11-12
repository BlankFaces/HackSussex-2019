using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSetSong : MonoBehaviour {

    public string song;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public string GetSong()
    {
        return song;
    }

    public void setSong(string iSong)
    {
        song = iSong;
    }
}
