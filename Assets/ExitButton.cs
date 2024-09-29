using UnityEngine;

public class ExitButton : MonoBehaviour
{
    // ����� ��� ������ �� ����
    public void ExitGame()
    {
#if UNITY_EDITOR
        // ��� ��������� Unity
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // ��� �����
        Application.Quit();
#endif
    }
}

