using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class TweenUI : MonoBehaviour
{

    public List<GameObject> items = new List<GameObject>();
    [SerializeField] private CanvasGroup title;

    [SerializeField] TextMeshProUGUI questionTxt;

    private void Awake()
    {
        ResetScaleUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(ItemsAnimation());
        }
    }

    public void AnimateTitle()
    {
        ResetScaleUI();
        title.alpha = 0f;
        title.DOFade(1f, 2f).SetEase(Ease.InQuint).OnComplete(QuestionAnim); ;
    }

    public void AnimateBtns()
    {
        StartCoroutine(ItemsAnimation());
    }

    public void QuestionAnim()
    {
        questionTxt.transform.DOScale(1f, 1f).SetEase(Ease.OutBounce).OnComplete(AnimateBtns);
    }

    public void ResetScaleUI()
    {
        questionTxt.transform.localScale = Vector3.zero;
        foreach (var item in items)
        {
            item.transform.localScale = Vector3.zero;
        }
    }

    IEnumerator ItemsAnimation()
    {
        foreach (var item in items)
        {
            //play one shot audio
            item.transform.DOScale(1f, 1f).SetEase(Ease.OutBounce);
            yield return new WaitForSeconds(0.25f);
        }
    }
}
