using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogcontrol : MonoBehaviour
{

    public GameObject mainCamera;

    public float step;

    public float threshold;

    Vector2 currentBlock = new Vector2 (-0.25f,-0.14f);

    public float elevation;

    List<Vector2> blockCoords = new List<Vector2>();

    Vector2 destination;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        
        destination = transform.position;
        blockCoords.Add(currentBlock);

        foreach (GameObject tile in mainCamera.GetComponent<CreateTiles>().tiles)
        {
            blockCoords.Add(tile.transform.position);
        }

        Debug.Log(blockCoords.Count);
    }

    float elapsed = 0f;

    public float distance_threshold;

    bool moving = false;

    // Update is called once per frame
    void Update()
    {
        if (!moving)
        {
            elapsed += Time.deltaTime;
        }
        //Debug.Log(elapsed);

        System.Random random = new System.Random();

        int index = random.Next(blockCoords.Count);

        Vector2 distance = blockCoords[index] - currentBlock;

        float xdiff = Mathf.Abs(distance.x);

        float ydiff = Mathf.Abs(distance.y);

        if (!moving && xdiff <= 0.25f && ydiff <= 0.14f && elapsed > threshold) {
            destination = blockCoords[index] + new Vector2(0, elevation);
            //Debug.Log("Moving to " + destination);
            moving = true;
        }
            
        transform.position = Vector2.MoveTowards((Vector2)transform.position, destination, Time.deltaTime * step);

        if (Vector2.Distance((Vector2)transform.position, destination) <= distance_threshold && moving)
        {
            currentBlock = destination - new Vector2(0, elevation);
            moving = false;
            elapsed = 0f;
        }
    }
}
