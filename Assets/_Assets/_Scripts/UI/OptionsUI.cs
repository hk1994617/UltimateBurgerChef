using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    public static OptionsUI instance {  get; private set; }


    [SerializeField] private Button soundEffectButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button moveUpButton;
    [SerializeField] private Button moveDownButton;
    [SerializeField] private Button moveLeftButton;
    [SerializeField] private Button moveRightButton;
    [SerializeField] private Button interactButton;
    [SerializeField] private Button interactAlternateButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private TextMeshProUGUI soundEffectText;
    [SerializeField] private TextMeshProUGUI musicText;
    [SerializeField] private TextMeshProUGUI moveUpText;
    [SerializeField] private TextMeshProUGUI moveDownText;
    [SerializeField] private TextMeshProUGUI moveRightText;
    [SerializeField] private TextMeshProUGUI moveLeftText;
    [SerializeField] private TextMeshProUGUI interactText;
    [SerializeField] private TextMeshProUGUI interactAlternateText;
    [SerializeField] private TextMeshProUGUI pauseText;
    [SerializeField] private Transform pressToRebindKeyTransform;

    private void Awake()
    {
        instance = this;
        soundEffectButton.onClick.AddListener(() =>
        {
            SoundManager.instance.CangeVolume();
            UpdateVisual();

        });
        musicButton.onClick.AddListener(() =>
        {
            MusicManager.instance.CangeVolume();
            UpdateVisual();
            
        });
        closeButton.onClick.AddListener(() =>
        {
            Hide();

        });

        moveUpButton.onClick.AddListener(() =>
        {
            RebindeBinding(GameInput.Binding.Move_Up);
        });
        moveDownButton.onClick.AddListener(() =>
        {
            RebindeBinding(GameInput.Binding.Move_Down);
        });
        moveLeftButton.onClick.AddListener(() =>
        {
            RebindeBinding(GameInput.Binding.Move_Left);
        });
        moveRightButton.onClick.AddListener(() =>
        {
            RebindeBinding(GameInput.Binding.Move_Right);
        });
        interactButton.onClick.AddListener(() =>
        {
            RebindeBinding(GameInput.Binding.Interact);
        });
        interactAlternateButton.onClick.AddListener(() =>
        {
            RebindeBinding(GameInput.Binding.InteractAlternate);
        });
        pauseButton.onClick.AddListener(() =>
        {
            RebindeBinding(GameInput.Binding.Pause);
        });
    }

    private void Start()
    {
        KitchenGameManager.instance.OnGameUnPaused += KitchenGameManager_OnGameUnPaused;

        UpdateVisual();
        Hide();
        HidePressTORebindKey();
    }

    private void KitchenGameManager_OnGameUnPaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void UpdateVisual()
    {
        soundEffectText.text = "Sound Effects: " + Mathf.Round(SoundManager.instance.GetVolume() * 10f);
        musicText.text = "Music: " + Mathf.Round(MusicManager.instance.GetVolume() * 10f);

        moveUpText.text = GameInput.Instance.GetBindingTexst(GameInput.Binding.Move_Up);
        moveDownText.text = GameInput.Instance.GetBindingTexst(GameInput.Binding.Move_Down);
        moveLeftText.text = GameInput.Instance.GetBindingTexst(GameInput.Binding.Move_Left);
        moveRightText.text = GameInput.Instance.GetBindingTexst(GameInput.Binding.Move_Right);
        interactText.text = GameInput.Instance.GetBindingTexst(GameInput.Binding.Interact);
        interactAlternateText.text = GameInput.Instance.GetBindingTexst(GameInput.Binding.InteractAlternate);
        pauseText.text = GameInput.Instance.GetBindingTexst(GameInput.Binding.Pause);
        
    }


    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void ShowPressTORebindKey()
    {
        pressToRebindKeyTransform.gameObject.SetActive(true);
    }
    private void HidePressTORebindKey()
    {
        pressToRebindKeyTransform.gameObject.SetActive(false);
    }

    private void RebindeBinding(GameInput.Binding binding)
    {
        ShowPressTORebindKey();
        GameInput.Instance.RebinBinding(binding,() => 
        {
            HidePressTORebindKey();
            UpdateVisual();
        });
    }
}
