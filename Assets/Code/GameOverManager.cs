using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;

    public void SetGameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
