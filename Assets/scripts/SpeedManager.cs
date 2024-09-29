using UnityEngine;
using UnityEngine.SceneManagement;

public class SpeedManager : MonoBehaviour
{
    public  static SpeedManager Instance { get; private set; }
    // speed increment of obstacles
    public float moveSpeed = 1.0f;
    public float speedIncrement = 0.01f;
    public float timeInterval = 1.0f;

    private float lastIncrementTime;

    private float initialSpeed = 1f;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        moveSpeed = initialSpeed;
        lastIncrementTime = Time.time;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update()
    {
        if(Time.time - lastIncrementTime >= timeInterval)
        {
            moveSpeed += speedIncrement;
            lastIncrementTime = Time.time;
        }
    }
    void OnSceneLoaded(Scene scene , LoadSceneMode mode)
    {
        moveSpeed = initialSpeed;
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
