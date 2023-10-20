using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBoxFinger : MonoBehaviour
{
    public GameObject particlesSpawn;

    public enum InputStyle { MOUSE, TOUCHES }
    public InputStyle inputStyle;
    //public ParticleSystem particle;
    //public List<GameObject> particles = new List<GameObject>();

    void WhackMole()
    {
        switch (inputStyle)
        {
            case InputStyle.MOUSE:
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        // If I hit a mole
                        if (hit.collider.gameObject)
                        {
                            Instantiate(particlesSpawn, hit.point, Quaternion.identity);
                            //hit.collider.gameObject.GetComponent<TakeDamage>().TakeDamages(1f);
                        }
                    }
                }
                break;

            case InputStyle.TOUCHES:
                if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);

                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        // If I hit a mole
                        if (hit.collider.gameObject)
                        {
                            Instantiate(particlesSpawn, hit.point, Quaternion.identity);
                            Debug.Log("ENTER");
                            //hit.collider.gameObject.GetComponent<TakeDamage>().TakeDamages(1f);
                        }
                    }
                }

                else
                {
                    Debug.Log("CLOSE");
                }
                break;
        }
    }

    void Update()
    {
        WhackMole();
    }
}
