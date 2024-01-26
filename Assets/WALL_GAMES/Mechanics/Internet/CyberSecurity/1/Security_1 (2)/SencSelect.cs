using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SencSelect : MonoBehaviour
{
    public GameObject[] checkSend;
    public GameObject[] completeObj;

    public GameObject winPanel;

    public AudioSource audioPlaying;
    public AudioClip win;
    public AudioClip lose;

    public void CheckSend()
    {
        StartCoroutine(Check());
    }

    IEnumerator Check()
    {
        winPanel.SetActive(true);

        yield return new WaitForSeconds(2f);

        for (int i = 0; i < checkSend.Length; i++)
        {
            checkSend[i].SetActive(true);

            if (completeObj[0].activeSelf && completeObj[1].activeSelf &&
                completeObj[2].activeSelf && completeObj[3].activeSelf &&
                completeObj[4].activeSelf)
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
    }
}
