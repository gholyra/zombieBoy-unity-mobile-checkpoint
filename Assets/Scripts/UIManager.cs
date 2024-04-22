using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI collectionText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        
    }

    public void SetTimerText(int minutes, int seconds)
    {
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    public void SetCollectionText(int collectedNumber, int toBeCollectedNumber)
    {
        collectionText.text = collectedNumber.ToString() + "/" + toBeCollectedNumber;
    }
}
