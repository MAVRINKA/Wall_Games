using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBool : MonoBehaviour
{
    public bool isActive;
    private void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // If I hit a mole
                if (hit.collider.gameObject)
                {
                    isActive = true;
                    //hit.collider.gameObject.GetComponent<TakeDamage>().TakeDamages(1f);
                }             
            }

            else
            {
                isActive = false;
            }
        } 

 

    }
}
