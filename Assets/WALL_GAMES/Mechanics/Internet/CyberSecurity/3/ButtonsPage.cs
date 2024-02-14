using UnityEngine;
using UnityEngine.UI;

public class ButtonsPage : MonoBehaviour
{
    public Button[] buttons; // Массив кнопок
    public GameObject[] passwordObjects;
    public GameObject[] btnSelect;


    private void Start()
    {
        // Добавляем обработчик события при нажатии на каждую кнопку
        for (int i = 0; i < buttons.Length; i++)
        {
            int buttonIndex = i; // Индекс кнопки в массиве нужен для передачи в лямбда-функцию
            buttons[i].onClick.AddListener(() => OnButtonClick(buttonIndex));
        }
    }

    // Метод, вызываемый при нажатии на кнопку
    private void OnButtonClick(int buttonIndex)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i == buttonIndex)
            {
                // Если нажата кнопка с индексом buttonIndex, делаем ее неактивной
                //buttons[i].interactable = false;
                passwordObjects[i].SetActive(true);
                btnSelect[i].SetActive(true);
            }
            else
            {
                // Если нажата другая кнопка, делаем ее неактивной, а остальные кнопки активными
                //buttons[i].interactable = true;
                passwordObjects[i].SetActive(false);
                btnSelect[i].SetActive(false);
            }
        }
    }
}