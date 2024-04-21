using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [SerializeField] private float matchTime;
    [SerializeField] private int pumpkinsToBeCollected = 30;

    public int pumpkinsCollected { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        StartCoroutine(StartCounting());
    }

    private void Update()
    {
        UIManager.Instance.SetTimerText(matchTime);
    }

    private void GameOver()
    {
        if (matchTime <= 0f)
        {
            if (pumpkinsCollected == pumpkinsToBeCollected)
            {
                // GANHOU!
            }
            else
            {
                // PERDEU!
            }
        }
    }
    
    private IEnumerator StartCounting()
    {
        matchTime--;
        yield return new WaitForSeconds(1f);
    }
}
