using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private int playerCoins = 0;
    [SerializeField] private int playerGems = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        Debug.Log("GameManager initialized. Coins: " + playerCoins);
    }

    public void AddCoins(int amount)
    {
        playerCoins += amount;
        Debug.Log("Coins updated: " + playerCoins);
    }

    public void AddGems(int amount)
    {
        playerGems += amount;
        Debug.Log("Gems updated: " + playerGems);
    }

    public int GetCoins() => playerCoins;
    public int GetGems() => playerGems;
}
