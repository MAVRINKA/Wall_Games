using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendsCheck : MonoBehaviour
{
    public GameObject[] checkSend;
    public GameObject[] completeObj;

    public GameObject winPanel;
    public GameObject winInfo;

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

        for (int i = 0; i < checkSend.Length; i++)
        {
            checkSend[i].SetActive(true);

            if (completeObj[0].activeSelf && completeObj[1].activeSelf &&
                completeObj[2].activeSelf && completeObj[3].activeSelf)
            {
                Debug.Log("œŒ¡≈ƒ¿!");
                winPanel.GetComponent<Image>().color = Color.green;
                audioPlaying.PlayOneShot(win);
                winInfo.SetActive(true);

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
