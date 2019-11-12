using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class InputField : MonoBehaviour
{
    public string URL;
    public string path;

    public GameObject invlaid;
    public GameObject valid;


    /*void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static InputField Instance { get; private set; } */


    public void MainStuff(string URLthing)
    {
        URL = URLthing; // Url to track

        if (URL != null) // If nothing not entered
        {
            valid.SetActive(true);
            path = Application.dataPath + "/Resources"; // Path to download song.mp3
            Process start = new Process();
            start.StartInfo.UseShellExecute = false;
            start.StartInfo.RedirectStandardOutput = true;
            start.StartInfo.CreateNoWindow = true;
            start.StartInfo.FileName = Application.dataPath + "/Executables/bandcamp.exe";
            start.StartInfo.Arguments = URL + " " + "\"" + path + "\"";
            start.Start();
            string output = start.StandardOutput.ReadToEnd();
            start.WaitForExit();
            UnityEngine.Debug.Log(output);

            if (output == "2")
            {
                // Set text to say file was deleted after downloading
                valid.SetActive(false);
                invlaid.SetActive(true);
            }

            else if (output == "3")
            {
                // Set text to say network error, try again
                valid.SetActive(false);
                invlaid.SetActive(true);
            }

            else if (output == "4")
            {
                // Set text to say invalid URL
                valid.SetActive(false);
                invlaid.SetActive(true);
            }

            else
            {
                UnityEngine.Debug.Log(1);
                GameObject go = GameObject.Find("Song Holder");
                GetSetSong AudioThing = go.GetComponent<GetSetSong>();
                AudioThing.setSong(output);
                UnityEngine.Debug.Log(2);
                invlaid.SetActive(false);
                valid.SetActive(true);
                StartCoroutine(LoadNextScene());
            }
        }

        else
        {
            // Set text to say nothing was inputted
            invlaid.SetActive(true);
        }
    }

    public IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(10f);
       SceneManager.LoadScene("Light");
   }
}



