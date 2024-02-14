using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LineSelect : MonoBehaviour
{
    public GameObject[] imagesComplete;
    public Image imgCheck;
    public AudioSource audioPlaying;
    public AudioClip win;
    public AudioClip lose;

    public GameObject infoPanel;

    private void Update()
    {
        //CheckComplete();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckComplete();
        }
    }

    IEnumerator WinPanel()
    {
        yield return new WaitForSeconds(2f);
        infoPanel.SetActive(true);
    }
    public void CheckComplete()
    {
        bool allActive = imagesComplete.All(image => image.activeSelf);

        if (allActive)
        {
            imgCheck.color = Color.green;
            audioPlaying.PlayOneShot(win);
            StartCoroutine(WinPanel());
            Debug.Log("Верно");
        }

        else
        {
            imgCheck.color = Color.red;
            audioPlaying.PlayOneShot(lose);
            Debug.Log("Неверно");
        }

        //if (imagesComplete[0].activeSelf && imagesComplete[1].activeSelf &&
        //    imagesComplete[2].activeSelf && imagesComplete[3].activeSelf)
        //{

        //    imgCheck.color = Color.green;
        //    audioPlaying.PlayOneShot(win);
        //    Debug.Log("Верно");
        //}
        //else
        //{
        //    imgCheck.color = Color.red;
        //    audioPlaying.PlayOneShot(lose);
        //    Debug.Log("Неверно");
        //}
    }
}
