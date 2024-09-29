using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject pauseSprite; // ������ �� ������ ����� (��������, UI Image)
    private bool isPaused = false;

    void Start()
    {
        PauseGame(); // ��������� ���� �� ����� � �������� ������ ��� ������
    }

    void Update()
    {
        // ���� ���� �� ����� � ���� ������ ����� ������ ��� ������� ������
        if (isPaused && (Input.anyKeyDown || Input.touchCount > 0))
        {
            ResumeGame(); // ����� ���� � �����
        }
    }

    void PauseGame()
    {
        pauseSprite.SetActive(true); // �������� ������
        Time.timeScale = 0f; // ���������� ����� � ����
        isPaused = true; // ��������, ��� ���� �� �����
    }

    void ResumeGame()
    {
        pauseSprite.SetActive(false); // �������� ������
        Time.timeScale = 1f; // ����������� ����� � ����
        isPaused = false; // ��������, ��� ���� ������������
    }
}
