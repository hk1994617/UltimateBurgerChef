using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject pauseSprite; // Ссылка на спрайт паузы (например, UI Image)
    private bool isPaused = false;

    void Start()
    {
        PauseGame(); // Поставить игру на паузу и показать спрайт при старте
    }

    void Update()
    {
        // Если игра на паузе и была нажата любая кнопка или касание экрана
        if (isPaused && (Input.anyKeyDown || Input.touchCount > 0))
        {
            ResumeGame(); // Снять игру с паузы
        }
    }

    void PauseGame()
    {
        pauseSprite.SetActive(true); // Показать спрайт
        Time.timeScale = 0f; // Остановить время в игре
        isPaused = true; // Пометить, что игра на паузе
    }

    void ResumeGame()
    {
        pauseSprite.SetActive(false); // Спрятать спрайт
        Time.timeScale = 1f; // Возобновить время в игре
        isPaused = false; // Пометить, что игра продолжается
    }
}
