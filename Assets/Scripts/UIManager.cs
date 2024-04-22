using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI collectionText;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject victoryScreen;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        SetGameOverScreenIsActive(false);
        SetVictoryScreenIsActive(false);
    }

    public void SetTimerText(int minutes, int seconds)
    {
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    public void SetCollectionText(int collectedNumber, int toBeCollectedNumber)
    {
        collectionText.text = collectedNumber.ToString() + "/" + toBeCollectedNumber;
    }
    
    public void SetGameOverScreenIsActive(bool isActive)
    {
        gameOverScreen.SetActive(isActive);
    }

    public void SetVictoryScreenIsActive(bool isActive)
    {
        victoryScreen.SetActive(isActive);
    }
}