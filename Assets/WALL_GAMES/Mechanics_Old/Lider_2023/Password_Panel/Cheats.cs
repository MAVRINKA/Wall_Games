using UnityEngine;
using TMPro;

public class Cheats : MonoBehaviour
{
    public TMP_InputField CommandLine;
    public GameObject password_Panel;

    private void Start()
    {
        CommandLine.characterLimit = 1;
    }

    void Update()
    {
        
    }

    //public void CheckLimitChar()
    //{
    //    if (CommandLine.text.Length > 4)
    //    {
    //        CommandLine.text = string.Empty;
    //    }
    //}

    public void ClearTxt()
    {
        
    }

    public void CheckPaswword()
    {
        if (CommandLine.text == "1234")
        {
            Debug.Log("СРАБОТАЛО");
            password_Panel.SetActive(false);
        }
    }

}
