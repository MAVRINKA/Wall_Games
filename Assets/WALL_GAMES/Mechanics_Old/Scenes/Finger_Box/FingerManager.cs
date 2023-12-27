using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerManager : MonoBehaviour
{
    public BoxBool[] boxColliders;
    private void Update()
    {

        if (boxColliders[0].isActive == true && boxColliders[1].isActive == true)
        {
            Debug.Log("LOVE");
        }

        else
        {
                  Debug.Log("LOVEEEEEEEEEEEEEEEEEEEEER");
        }
            //for(int i = 0; i < boxColliders.Length; i++)
            //{
            //    if (boxColliders[i].isActive == true)
            //    {
            //        Debug.Log("LOVE");
            //    }

            //    else {
            //        Debug.Log("LOVEEEEEEEEEEEEEEEEEEEEER");
            //    }
            //}
        }
    }
