using System;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance;

    private bool touched;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.Contains("Menu"))
        {
            if (Touch())
            {
                LoadMyScene("InstructionScene");
            }
        }
        else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.Contains("Instruction"))
        {
            if (Touch())
            {
                LoadMyScene("GameScene");
            }
        }
    }

    private bool Touch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended)
            {
                return true;
            }
        }
        return false;
    }

    public void LoadMyScene(string scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
}
