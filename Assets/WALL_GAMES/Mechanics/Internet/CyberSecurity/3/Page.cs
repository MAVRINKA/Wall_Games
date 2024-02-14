using UnityEngine;
using UnityEngine.UI;

public class Page : MonoBehaviour
{
    public Button[] buttons; // Массив кнопок
    public GameObject[] sendObjects;
    public GameObject[] sendBtnSelect;
    //public GameObject[] pop;


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
                sendObjects[i].SetActive(true);
                sendBtnSelect[i].SetActive(true);
                //pop[i].SetActive(true);
            }
            else
            {
                // Если нажата другая кнопка, делаем ее неактивной, а остальные кнопки активными
                //buttons[i].interactable = true;
                sendObjects[i].SetActive(false);
                sendBtnSelect[i].SetActive(false);
            }
        }
    }
}