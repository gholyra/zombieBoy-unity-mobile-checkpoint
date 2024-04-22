using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [FormerlySerializedAs("matchTime")] [SerializeField] private float matchTimeInSeconds; 
    [SerializeField] private int pumpkinsToBeCollected = 30;
    [SerializeField] private GameObject pumpkin;
    
    public int pumpkinsCollected { get; set; }
    public bool matchIsOver { get; private set; }

    private int matchTimeMinutes;
    private int matchTimeSeconds;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        Time.timeScale = 1;
    }

    private void Start()
    {
        StartCoroutine(SpawnPumpkins());
    }

    private void Update()
    {
        UIManager.Instance.SetTimerText(matchTimeMinutes, matchTimeSeconds);
        matchTimeInSeconds -= 1f * Time.deltaTime;
        
        UIManager.Instance.SetCollectionText(pumpkinsCollected, pumpkinsToBeCollected);
        
        CheckMatchStatus();
    }

    private void CheckMatchStatus()
    {
        if (matchTimeInSeconds < 1f)
        {
            matchIsOver = true;
            Time.timeScale = 0;
            if (pumpkinsCollected >= pumpkinsToBeCollected)
            {
                // GANHOU!
                UIManager.Instance.SetVictoryScreenIsActive(true);
                UIManager.Instance.SetGameOverScreenIsActive(false);
            }
            else
            {
                // PERDEU!
                UIManager.Instance.SetGameOverScreenIsActive(true);
                UIManager.Instance.SetVictoryScreenIsActive(false);
            }
        }
    }
    
    private IEnumerator SpawnPumpkins()
    {
        yield return new WaitForSeconds(2.5f);
        for (int i = 0; i < 20; i ++)
        {
            float posXRange = Random.Range(-20f, 20f);
            float posZRange = Random.Range(-20f, 20f);
            Instantiate(pumpkin, new Vector3(posXRange, 0f, posZRange), Quaternion.Euler(-90f, 0f, 0f));
        }
        StartCoroutine(SpawnPumpkins());
    }
    
    private void OnGUI()
    {
        matchTimeMinutes = Mathf.FloorToInt(matchTimeInSeconds / 60);
        matchTimeSeconds = Mathf.FloorToInt(matchTimeInSeconds % 60);
    }
}
