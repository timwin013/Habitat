using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 rayCastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayCastPosition, Vector2.zero);

            if (hit.collider != null)
            {
                Destroy(GameObject.Find("UpArrow"));
                //Instantiate(GameObject.Find("DownArrow"));

                //ButtonsDown.GetComponent<Renderer>.enabled = true;
            }
        }
    }
}
