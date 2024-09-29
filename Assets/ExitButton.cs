using UnityEngine;

public class ExitButton : MonoBehaviour
{
    // Метод для выхода из игры
    public void ExitGame()
    {
#if UNITY_EDITOR
        // Для редактора Unity
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Для билда
        Application.Quit();
#endif
    }
}

