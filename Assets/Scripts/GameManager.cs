using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [SerializeField] private float matchTime;
    [SerializeField] private int pumpkinsToBeCollected = 30;
    [SerializeField] private GameObject pumpkin;
    
    public int pumpkinsCollected { get; set; }

    private int matchTimeMinutes;
    private int matchTimeSeconds;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnPumpkins());
    }

    private void Update()
    {
        UIManager.Instance.SetTimerText(matchTimeMinutes, matchTimeSeconds);
        matchTime -= 1f * Time.deltaTime;
        
        UIManager.Instance.SetCollectionText(pumpkinsCollected, pumpkinsToBeCollected);
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
    
    private IEnumerator SpawnPumpkins()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            float posXRange = Random.Range(-25f, 25f);
            float posZRange = Random.Range(-25f, 25f);
            Instantiate(pumpkin, new Vector3(posXRange, 0f, posZRange), Quaternion.identity);
        }
    }
    
    private void OnGUI()
    {
        matchTimeMinutes = Mathf.FloorToInt(matchTime / 60);
        matchTimeSeconds = Mathf.FloorToInt(matchTime % 60);
    }
}
