using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class getdate : MonoBehaviour
{
    DateTime localDate;
    TMP_Text boxText;
    // Start is called before the first frame update
    void Start()
    {
        localDate = DateTime.Now;
        int day = localDate.Day;
        int month = localDate.Month;

        boxText = GetComponent<TMP_Text>();
        boxText.text = day.ToString() + " " + localDate.ToString("MMMM");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
