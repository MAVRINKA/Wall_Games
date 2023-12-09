using UnityEngine;

public class InputStyles : MonoBehaviour
{
    public GameObject particlesSpawnEffect;
    public bool colorEffect;

    public enum InputStyle { MOUSE, TOUCHES }
    public InputStyle inputStyle;

    void InputController()
    {
        switch (inputStyle)
        {
            case InputStyle.MOUSE:
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        if (hit.collider.gameObject)
                        {
                            DamageHit(hit);
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
                        if (hit.collider.gameObject)
                        {
                            DamageHit(hit);
                        }
                    }
                }
                break;
        }     
    }

    private void DamageHit(RaycastHit hit)
    {
        var newParticle = Instantiate(particlesSpawnEffect, hit.point, Quaternion.identity);
        hit.collider.gameObject.GetComponent<TakeDamage>().TakeDamages(1f);

        //if (colorEffect)
        //{
        //    newParticle.GetComponent<SpriteRenderer>().color = hit.collider.gameObject.GetComponent<ColorHit>().colorImg;
        //} else
        //{
        //    newParticle.GetComponent<SpriteRenderer>().color = Color.green;
        //}
    }

    void Update()
    {
        InputController();
    }

    //GameObject SpawnObjects()
    //{
    //    Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
    //    Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
    //    return Instantiate(particlesSpawn, worldPos, particlesSpawn.transform.rotation);
    //}
}
