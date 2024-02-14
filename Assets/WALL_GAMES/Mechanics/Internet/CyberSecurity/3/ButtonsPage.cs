using UnityEngine;
using UnityEngine.UI;

public class ButtonsPage : MonoBehaviour
{
    public Button[] buttons; // ������ ������
    public GameObject[] passwordObjects;
    public GameObject[] btnSelect;


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
                passwordObjects[i].SetActive(true);
                btnSelect[i].SetActive(true);
            }
            else
            {
                // ���� ������ ������ ������, ������ �� ����������, � ��������� ������ ���������
                //buttons[i].interactable = true;
                passwordObjects[i].SetActive(false);
                btnSelect[i].SetActive(false);
            }
        }
    }
}