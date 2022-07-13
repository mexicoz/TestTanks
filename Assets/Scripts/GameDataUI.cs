
using TMPro;
using UnityEngine;

public class GameDataUI : MonoBehaviour
{
    [SerializeField] private TMP_Text playerCountText;
    [SerializeField] private TMP_Text enemyCountText;
    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
        gameManager.SetEnemyCount += UpdateEnemyCountUI;
        gameManager.SetPlayerCount += UpdatePlayerCountUI;
    }

    public void UpdatePlayerCountUI(int playerCount)
    {
        playerCountText.text = playerCount.ToString();
    }
    public void UpdateEnemyCountUI(int enemyCount)
    {
        enemyCountText.text = enemyCount.ToString();
    }
}
