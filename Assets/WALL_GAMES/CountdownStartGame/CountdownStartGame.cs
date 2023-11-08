using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CountdownStartGame : MonoBehaviour
{
    [Range(0, 5)]
    [SerializeField] private int countdownTime;
    [SerializeField] private TextMeshProUGUI countdownDisplay;

    [SerializeField] UnityEvent actionToStart;
    private void Start()
    {
        StartCoroutine(CountDownToStart());
    }

    IEnumerator CountDownToStart()
    {
        while(countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1);

            countdownTime--;
        }

        countdownDisplay.text = "������!";

        //������ ����������� ����
        actionToStart.Invoke();

        yield return new WaitForSeconds(1);

        countdownDisplay.gameObject.SetActive(false);
    }
}
