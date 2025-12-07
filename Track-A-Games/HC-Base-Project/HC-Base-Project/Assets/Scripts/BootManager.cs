using UnityEngine;
using UnityEngine.SceneManagement;

public class BootManager : MonoBehaviour
{
    [SerializeField] private float delayBeforeTransition = 1f;

    private void Start()
    {
        Debug.Log("[BootManager] Boot scene started. Transitioning to MainMenu in " + delayBeforeTransition + " seconds...");

        // Transition to MainMenu after delay
        Invoke(nameof(GoToMainMenu), delayBeforeTransition);
    }

    private void GoToMainMenu()
    {
        Debug.Log("[BootManager] Loading MainMenu scene...");
        SceneManager.LoadScene("MainMenu");
    }
}
