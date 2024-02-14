using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPhotos : MonoBehaviour
{
    public GameObject[] photosSelect;
    public void ResetPhoto()
    {
        for (int i = 0; i < photosSelect.Length; i++)
        {
            photosSelect[i].SetActive(false);
        }
    }
}
