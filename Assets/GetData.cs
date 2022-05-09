using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


public class GetData : MonoBehaviour
{
    string FILENAME = "step-data.txt";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Tuple<int,int>> getMonthData()
    {
        var MonthData = new List<Tuple<int,int>>();

        using (var file = new StreamReader(Application.dataPath + "\\Data\\" + FILENAME))
        {
            while (file.Peek() >= 0)
            {
                var line = file.ReadLine().Split(':');
                var date = DateTime.Parse(line[0]);
                
                if (date.Month != DateTime.Today.Month)
                    break;
                
                MonthData.Add(new Tuple<int,int>(Int32.Parse(line[1]), Int32.Parse(line[2])));
                
            }
        }
        return MonthData;
    }

    public List<Tuple<int,int>> getYearData()
    {
        var YearData = new List<Tuple<int,int>>();

        using (var file = new StreamReader(Application.dataPath + "\\Data\\" + FILENAME))
        {
            while (file.Peek() >= 0)
            {
                var line = file.ReadLine().Split(':');
                var date = DateTime.Parse(line[0]);
                
                if (date.Year != DateTime.Today.Year)
                    break;
                
                YearData.Add(new Tuple<int,int>(Int32.Parse(line[1]), Int32.Parse(line[2])));
                
            }
        }
        return YearData;
    }


}

