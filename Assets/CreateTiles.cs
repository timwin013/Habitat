using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

public class CreateTiles : MonoBehaviour
{
    public GameObject crate;
    public GameObject crate_n;
    public GameObject crate_s;

    public GameObject tile;
    public GameObject dirt;

    public GameObject tile_n;
    public GameObject dirt_n;

    public GameObject tile_s;
    public GameObject dirt_s;

    public GameObject streak;
    public GameObject streak_n;
    public GameObject streak_s;

    public GameObject shrub;
    public GameObject shrub_n;
    public GameObject shrub_s;

    public GameObject tree;
    public GameObject tree_n;
    public GameObject tree_s;

    public GameObject fountain;
    public GameObject fountain_n;
    public GameObject fountain_s;

    public GameObject fox;
    public GameObject squirrel;

    float xinc = 0.25f;
    float yinc = 0.14f;

    List<bool> record = new List<bool>()
    {
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true,
        true
    };

    public ArrayList tiles = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        var getData = GetComponent("GetData") as GetData;

        string selectedCharacter = GameObject.Find("EventSystem").GetComponent<Options>().character;
        
        if (selectedCharacter == "Squirrel")
        {
            Instantiate(squirrel, new Vector2(-0.25f, 0.14f), Quaternion.identity);
        }
        else
        {
            Instantiate(fox, new Vector2(-0.25f, 0.14f), Quaternion.identity);
        }

        record = getData.getMonthData().Select(t => t.Item1 > t.Item2).ToList();
        //record = getData.getYearData().Select(t => t.Item1 > t.Item2).ToList();

        int xcurrent = 0;
        int ycurrent = 0;

        int xmax = 1;
        int ymax = 2;

        float xnext = 0;
        float ynext = 0;

        bool xincreasing = true;
        bool yincreasing = true;

        int layer = 0;

        string time;

        DateTime localDate = DateTime.Now;

        int hour = localDate.Hour;

        if (hour > 8 && hour <= 17)
        {
            time = "day";
            Instantiate(crate, new Vector2(-0.25f, -0.14f), Quaternion.identity);
        }
        else if (hour < 6 || hour > 19)
        {
            time = "night";
            Instantiate(crate_n, new Vector2(-0.25f, -0.14f), Quaternion.identity);
        }
        else
        {
            time = "sunset";
            Instantiate(crate_s, new Vector2(-0.25f, -0.14f), Quaternion.identity);
        }

        int streakCount = 0;

        foreach (bool goal in record){
            
            GameObject newTile;

            if (goal)
            {
                streakCount++;

                if (time == "day")
                {
                    if (streakCount % 30 == 0)
                    {
                        newTile = Instantiate(tile, new Vector2(xnext, ynext), Quaternion.identity);
                        GameObject a_fountain = Instantiate(fountain, new Vector2(xnext, ynext+0.2f), Quaternion.identity);
                    }
                    else if (streakCount % 10 == 0)
                    {
                        newTile = Instantiate(tile, new Vector2(xnext, ynext), Quaternion.identity);
                        GameObject a_tree = Instantiate(tree, new Vector2(xnext, ynext + 0.3f), Quaternion.identity);
                    }
                    else if (streakCount % 5 == 0)
                    {
                        newTile = Instantiate(streak, new Vector2(xnext, ynext), Quaternion.identity);
                        tiles.Add(newTile);
                    }
                    else if (streakCount % 3 == 0)
                    {
                        newTile = Instantiate(shrub, new Vector2(xnext, ynext), Quaternion.identity);
                    }
                    else{
                        newTile = Instantiate(tile, new Vector2(xnext, ynext), Quaternion.identity);
                        tiles.Add(newTile);
                    }
                }
                else if (time == "night")
                {
                    if (streakCount % 30 == 0)
                    {
                        newTile = Instantiate(tile_n, new Vector2(xnext, ynext), Quaternion.identity);
                        GameObject a_fountain = Instantiate(fountain_n, new Vector2(xnext, ynext + 0.2f), Quaternion.identity);
                    }
                    else if (streakCount % 10 == 0)
                    {
                        newTile = Instantiate(tile_n, new Vector2(xnext, ynext), Quaternion.identity);
                        GameObject a_tree = Instantiate(tree_n, new Vector2(xnext, ynext + 0.3f), Quaternion.identity);
                    }
                    else if (streakCount % 5 == 0)
                    {
                        newTile = Instantiate(streak_n, new Vector2(xnext, ynext), Quaternion.identity);
                        tiles.Add(newTile);
                    }
                    else if (streakCount % 3 == 0)
                    {
                        newTile = Instantiate(shrub_n, new Vector2(xnext, ynext), Quaternion.identity);
                    }
                    else
                    {
                        newTile = Instantiate(tile_n, new Vector2(xnext, ynext), Quaternion.identity);
                        tiles.Add(newTile);
                    }
                }
                else
                {
                    if (streakCount % 30 == 0)
                    {
                        newTile = Instantiate(tile_s, new Vector2(xnext, ynext), Quaternion.identity);
                        GameObject a_fountain = Instantiate(fountain_s, new Vector2(xnext, ynext + 0.2f), Quaternion.identity);
                    }
                    else if (streakCount % 10 == 0)
                    {
                        newTile = Instantiate(tile_s, new Vector2(xnext, ynext), Quaternion.identity);
                        GameObject a_tree = Instantiate(tree_s, new Vector2(xnext, ynext + 0.3f), Quaternion.identity);
                    }
                    else if (streakCount % 5 == 0)
                    {
                        newTile = Instantiate(streak_s, new Vector2(xnext, ynext), Quaternion.identity);
                        tiles.Add(newTile);
                    }
                    else if (streakCount % 3 == 0)
                    {
                        newTile = Instantiate(shrub_s, new Vector2(xnext, ynext), Quaternion.identity);
                    }
                    else
                    {
                        newTile = Instantiate(tile_s, new Vector2(xnext, ynext), Quaternion.identity);
                        tiles.Add(newTile);
                    }
                }
            }
            else
            {
                streakCount = 0;
                
                if (time == "day")
                {
                    newTile = Instantiate(dirt, new Vector2(xnext, ynext), Quaternion.identity);
                    tiles.Add(newTile);
                }
                else if (time == "night")
                {
                    newTile = Instantiate(dirt_n, new Vector2(xnext, ynext), Quaternion.identity);
                    tiles.Add(newTile);
                }
                else
                {
                    newTile = Instantiate(dirt_s, new Vector2(xnext, ynext), Quaternion.identity);
                    tiles.Add(newTile);
                }
            }

            newTile.GetComponent<SpriteRenderer>().sortingOrder = layer;

            xcurrent++;
            ycurrent++;

            if (xcurrent == xmax)
            {
                xcurrent = 0;
                xmax += 2;
                xincreasing = !xincreasing;
            }

            if (ycurrent == ymax)
            {
                ycurrent = 0;
                ymax += 2;
                yincreasing = !yincreasing;
            }

            if (xincreasing)
            {
                xnext = (float)(xnext + xinc);
            }
            else
            {
                xnext = (float)(xnext - xinc);
            }

            if (yincreasing)
            {
                ynext = (float)(ynext + yinc);
                layer--;
            }
            else
            {
                ynext = (float)(ynext - yinc);
                layer++;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
