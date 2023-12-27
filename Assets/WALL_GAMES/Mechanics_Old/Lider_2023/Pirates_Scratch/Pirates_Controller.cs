using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirates_Controller : MonoBehaviour
{
    public int scoreScratch;
    public GameObject hideObject;
    public GameObject passwordPanel;

    private void Start()
    {
        scoreScratch = 0;
    }

    private void Update()
    {
        if(scoreScratch >= 2)
        {
            StartCoroutine(TimeActive());
        }
    }

    public void ScoreUp()
    {
        scoreScratch++;
    }

    public IEnumerator TimeActive()
    {
        yield return new WaitForSeconds(10f);
        hideObject.SetActive(false);
        passwordPanel.SetActive(true);
        StopAllCoroutines();
    }
}
