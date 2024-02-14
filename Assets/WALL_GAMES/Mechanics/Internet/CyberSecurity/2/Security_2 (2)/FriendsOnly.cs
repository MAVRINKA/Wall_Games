using UnityEngine;
using UnityEngine.UI;

public class FriendsOnly : MonoBehaviour
{
    public Button[] buttons; // ������ ������
    public GameObject[] sendObjects;


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
            }
            else
            {
                // ���� ������ ������ ������, ������ �� ����������, � ��������� ������ ���������
                //buttons[i].interactable = true;
                sendObjects[i].SetActive(false);
            }
        }
    }
}