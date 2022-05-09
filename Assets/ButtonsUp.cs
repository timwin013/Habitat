using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsUp : MonoBehaviour
{
    public void UpChanges(bool Up)
    {
        if (Up)
        {
            transform.position = new Vector3(0f, -3f, 0f);
        }
    }
}