using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizCheck : MonoBehaviour
{
    public GameObject[] imagesComplete;
    public Image img;
    public GameObject winPanel;

    public AudioSource audioPlaying;
    public AudioClip win;
    public AudioClip lose;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckComplete();
        }
    }

    public void CheckComplete()
    {

        if (imagesComplete[0].activeSelf)
        {
            img.color = Color.green;
            audioPlaying.PlayOneShot(win);
            Debug.Log("Верно");
            winPanel.SetActive(true);
        }
        else
        {
            img.color = Color.red;
            audioPlaying.PlayOneShot(lose);
            Debug.Log("Неверно");
        }
    }
}
