using UnityEngine;
using UnityEngine.UI;

public class SleepSceneUIAnim : MonoBehaviour
{
    [SerializeField] private
    GameObject background;

    [Range(0, 10)]
    [SerializeField] private
    float timeAnim;

    private Button startBtn;
    void Start()
    {
        startBtn = GetComponent<Button>();
        startBtn.onClick.AddListener(() => StartInstallation());
    }
    public void StartInstallation()
    {
        startBtn.gameObject.SetActive(false);
        LeanTween.scale(background, new Vector3(8f, 8f, 1f), timeAnim).setEase(LeanTweenType.easeOutCirc);
    }

}
