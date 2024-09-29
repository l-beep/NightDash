using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuETvenths : MonoBehaviour
{
    public GameObject AudioOnIcon;
    public GameObject AudioOffIcon;


    //Best score
    public Text txtBestScore;

    private void Start()
    {
        SetSoundState();
        txtBestScore.text = PlayerPrefs.GetFloat("BestScore", 0).ToString("00.00");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void StartGame()
    {
        string Level = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Level");
    }

    public void ToggleSound()
    {
        if(PlayerPrefs.GetInt("Mute",0) == 0)
        {
            PlayerPrefs.SetInt("Mute", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Mute", 0);
        }
        SetSoundState();
    }
    private void SetSoundState()
    {
        if(PlayerPrefs.GetInt("Mute",0) == 0)
        {
            AudioListener.volume = 1;
            AudioOnIcon.SetActive(true);
            AudioOffIcon.SetActive(false);
        }
        else
        {
            AudioListener.volume = 0;
            AudioOnIcon.SetActive(false);
            AudioOffIcon.SetActive(true);
        }
        
    }
}
