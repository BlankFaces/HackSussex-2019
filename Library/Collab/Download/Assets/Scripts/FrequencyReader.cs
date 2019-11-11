using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;
using UnityEngine.SceneManagement;

[RequireComponent (typeof (AudioSource))]
public class FrequencyReader : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip clippywippyuwu;

    public static float[] samples = new float[8192]; //8192


    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        //audioSource.clip = clippywippyuwu;
        //audioSource.Play();

        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot((AudioClip)Resources.Load("song"));

        StartCoroutine(WaitToEnd());
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
    }

    // Divides up mp3 into the length of _samples into float values depending on the peak of the wave.
    void GetSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    public IEnumerator WaitToEnd()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        SceneManager.LoadScene("Menu");
    } 
}
