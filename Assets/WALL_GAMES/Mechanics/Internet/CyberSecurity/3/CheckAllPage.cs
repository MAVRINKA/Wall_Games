using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CheckAllPage : MonoBehaviour
{
    public GameObject[] checkSend;
    public GameObject[] completeObj;
    public GameObject[] falseObj;

    public GameObject noObj;

    public GameObject winPanel;

    public AudioSource audioPlaying;
    public AudioClip win;
    public AudioClip lose;


    public Color defaultColor;

    private void Update()
    {
        //CheckComplete();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckSend();
        }
    }

    public void CheckSend()
    {
        StartCoroutine(Check());
    }

    IEnumerator Check()
    {
        winPanel.SetActive(true);

        yield return new WaitForSeconds(2f);

        bool allActive = completeObj.All(image => image.activeSelf);
        bool allFalse = falseObj.All(image => !image.activeSelf);

        for (int i = 0; i < checkSend.Length; i++)
        {
            checkSend[i].SetActive(true);

            if (allActive && allFalse)
            {
                Debug.Log("œŒ¡≈ƒ¿!");
                winPanel.GetComponent<Image>().color = Color.green;
                audioPlaying.PlayOneShot(win);
            }
            else
            {
                Debug.Log("œŒ–¿∆≈Õ»≈!");
                winPanel.GetComponent<Image>().color = Color.red;
                audioPlaying.PlayOneShot(lose);
            }

            checkSend[i].SetActive(false);
        }

        yield return new WaitForSeconds(2f);
        winPanel.SetActive(false);
        winPanel.GetComponent<Image>().color = defaultColor;

    }
}
