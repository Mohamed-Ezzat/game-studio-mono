using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimpleAdManager : MonoBehaviour
{
    [SerializeField] private Button watchAdButton;
    [SerializeField] private int coinsReward = 10;
    [SerializeField] private TextMeshProUGUI coinDisplayText;

    private void Start()
    {
        if (watchAdButton != null)
        {
            watchAdButton.onClick.AddListener(OnWatchAdClicked);
            Debug.Log("[SimpleAdManager] Watch Ad button listener registered");
        }
        else
        {
            Debug.LogWarning("[SimpleAdManager] Watch Ad Button not assigned!");
        }

        // Update initial coin display
        UpdateCoinDisplay();
    }

    public void OnWatchAdClicked()
    {
        Debug.Log("[SimpleAdManager] Watch Ad button clicked!");
        RewardCoins();
    }

    private void RewardCoins()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddCoins(coinsReward);
            Debug.Log("[SimpleAdManager] Rewarded " + coinsReward + " coins. Total: " + GameManager.Instance.GetCoins());

            // Update UI immediately
            UpdateCoinDisplay();
        }
        else
        {
            Debug.LogError("[SimpleAdManager] GameManager.Instance is null!");
        }
    }

    private void UpdateCoinDisplay()
    {
        if (coinDisplayText != null && GameManager.Instance != null)
        {
            coinDisplayText.text = "Coins: " + GameManager.Instance.GetCoins();
        }
    }
}
