using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipesDeliveredTexst;
    private void Start()
    {    
        KitchenGameManager.instance.OnStateCanged += KitchenGameManager_OnStateCanged;
        Hide();
    }

    private void KitchenGameManager_OnStateCanged(object sender, System.EventArgs e)
    {
        if (KitchenGameManager.instance.IsGameOver())
        {
            Show();

            recipesDeliveredTexst.text = DeliveryManager.Instance.GetsuccesfulRecipesAmount().ToString();
            
        }
        else
        {
            Hide();
            
        }
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
