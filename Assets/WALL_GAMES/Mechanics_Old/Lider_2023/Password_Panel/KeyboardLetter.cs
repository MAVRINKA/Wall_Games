using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KeyboardLetter : MonoBehaviour
{
    private string word = null;
    public int wordIndex = 0;
    public TMP_InputField letterName;

    public Button[] btns;

    public GameObject password_Panel;
    public GameObject winBackground;

    private void Update()
    {
        letterName.text = word;

        if(letterName.text.Length > 4)
        {
            RemoveText();
        }
    }

    public void Alphavite(string alphavite)
    {
        wordIndex++;
        word = word + alphavite;
        StartCoroutine(NoActiveBtn());
    }

    public void RemoveLetter()
    {
        if(word.Length > 0)
        word = word.Remove(word.Length - 1, 1);
    }

    public void RemoveText()
    {
        word = string.Empty;
    }

    public void CheckPaswword()
    {
        if (letterName.text == "2115")
        {
            Debug.Log("—–¿¡Œ“¿ÀŒ");
            password_Panel.SetActive(false);
            winBackground.SetActive(true);
        } else
        {
            RemoveText();
            Debug.Log("Õ»’≈–¿");
            GetComponent<AudioSource>().Play();
        }
    }

    public IEnumerator NoActiveBtn()
    {
        NumberBtns(false);
        yield return new WaitForSeconds(1f);
        NumberBtns(true);
    }
    public void NumberBtns(bool boolean)
    {
        for (int i = 0; i < btns.Length; i++)
        {
            btns[i].interactable = boolean;
        }
    }
}
