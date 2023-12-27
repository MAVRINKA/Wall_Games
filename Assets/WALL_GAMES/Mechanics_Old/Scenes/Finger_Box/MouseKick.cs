using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseKick : MonoBehaviour
{
    public Image img;
    public bool bl = false;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        if (bl != false)
        {
            img.fillAmount += 0.01f;
        }
        else if(img.fillAmount > 0)
        {
            img.fillAmount -= 0.001f;
        }
    }

    public void OnMouseEnter()
    {
        bl = true;
        Debug.Log("Enter");
    }

    public void OnMouseDown()
    {
        bl = true;
        Debug.Log("Enter");
    }

    public void OnMouseExit()
    {
        bl = false;
        Debug.Log("Ex");
    }

    public void OnMouseUp()
    {
        bl = false;
        Debug.Log("Ex");
    }
}
