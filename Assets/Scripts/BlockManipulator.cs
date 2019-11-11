using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManipulator : MonoBehaviour
{
    public GameObject[] testCubes;

    public float multiplier;
    public float tempMult;

    public float count;
    public float average;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count = 0;
        for (int i = 0; i < 48; i++)
        {
            count += FrequencyReader.samples[i];
        }
        average = count / 48f;
        //Debug.Log("average = " + average);

        tempMult = 0.014f / average;
        if (tempMult > 150f)
        {
            tempMult = 150f;
        }
        //Debug.Log("tempMult = " + tempMult);

        for (int j = 0; j < 48; j++)
        {
            if (testCubes != null)
            {
                testCubes[j].transform.localScale = new Vector3((FrequencyReader.samples[j + 1] * multiplier * tempMult), 0.1927001f, 0.1f);
            }
        }
    }
}
