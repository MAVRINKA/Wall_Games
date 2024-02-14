using UnityEngine;
using UnityEngine.UI;

public class Page : MonoBehaviour
{
    public Button[] buttons; // ������ ������
    public GameObject[] sendObjects;
    public GameObject[] sendBtnSelect;
    //public GameObject[] pop;


    private void Start()
    {
        // ��������� ���������� ������� ��� ������� �� ������ ������
        for (int i = 0; i < buttons.Length; i++)
        {
            int buttonIndex = i; // ������ ������ � ������� ����� ��� �������� � ������-�������
            buttons[i].onClick.AddListener(() => OnButtonClick(buttonIndex));
        }
    }

    // �����, ���������� ��� ������� �� ������
    private void OnButtonClick(int buttonIndex)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i == buttonIndex)
            {
                // ���� ������ ������ � �������� buttonIndex, ������ �� ����������
                //buttons[i].interactable = false;
                sendObjects[i].SetActive(true);
                sendBtnSelect[i].SetActive(true);
                //pop[i].SetActive(true);
            }
            else
            {
                // ���� ������ ������ ������, ������ �� ����������, � ��������� ������ ���������
                //buttons[i].interactable = true;
                sendObjects[i].SetActive(false);
                sendBtnSelect[i].SetActive(false);
            }
        }
    }
}