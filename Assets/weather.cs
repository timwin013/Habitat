using System.Collections;
using System.Collections.Generic;
//using System.Globalization;
using System;
using UnityEngine;

public class weather : MonoBehaviour
{
    public GameObject night;
    public GameObject day;
    public GameObject sunset;

    // Start is called before the first frame update
    void Start()
    {
        DateTime localDate = DateTime.Now;

        int hour = localDate.Hour;
        if (hour > 8 && hour <= 17)
        {
            Instantiate(day, new Vector2(9.69f, -3.18f), Quaternion.identity);
            Instantiate(day, new Vector2(9.69f + 19f, -3.18f), Quaternion.identity);
        }
        else if (hour < 6 || hour > 19)
        {
            Instantiate(night, new Vector2(4.53f, -5.08f), Quaternion.identity);
            Instantiate(night, new Vector2(4.53f+19f, -5.08f), Quaternion.identity);
        }
        else
        {
            Instantiate(sunset, new Vector2(7.54f, -1.77f), Quaternion.identity);
            Instantiate(sunset, new Vector2(7.54f + 19f, -1.77f), Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
