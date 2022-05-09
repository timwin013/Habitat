using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsDown : MonoBehaviour
{
    public void DownChanges(bool Down)
    {
        if (Down)
        {
            transform.position = new Vector3(0f, -6f, 0f);
        }
    }
}
