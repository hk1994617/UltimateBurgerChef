using TMPro;
using UnityEngine;

public class GameStartCountDownUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countDownText;

    private void Start()
    {    
        KitchenGameManager.instance.OnStateCanged += KitchenGameManager_OnStateCanged;
        Hide();
    }

    private void KitchenGameManager_OnStateCanged(object sender, System.EventArgs e)
    {
        if (KitchenGameManager.instance.IsCountDownToStartActive())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Update()
    {
        countDownText.text = Mathf.Ceil(KitchenGameManager.instance.GetCountDownToStartTimer()).ToString();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
