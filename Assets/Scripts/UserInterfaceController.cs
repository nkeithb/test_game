using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UserInterfaceController : MonoBehaviour {

    public static UserInterfaceController instance = null;

    private Text countText;
    private Text levelText;
    internal Text levelOverText;
    private Text powerUpText;
    private GameObject levelImage;
    private GameObject pauseText;

    void Awake()
    {
        CheckInstantiation();
        FindGameObjects();
       
    }
    public void ShowPauseText()
    {
        pauseText.SetActive(true);
    }

    public void HidePauseText()
    {
        pauseText.SetActive(false);
    }

    public void ShowPowerUpText()
    {
        powerUpText.text = "PowerUp Active! 5x Score!";
    }

    public void HidePowerUpText()
    {
        powerUpText.text = "";
    }

    public void SetAndShowLevelText(string level)
    {
        HidePauseText();
        levelText.text = level;
        levelOverText.text = "";
        levelImage.SetActive(true);
    }   

    public void SetAndShowLevelOverText(string textToUse)
    {
        HidePauseText();
        levelText.text = "";
        levelOverText.text = textToUse;
        levelImage.SetActive(true);
    }

    public void SetAndShowCountText(int count)
    {
        countText.text = "Score: " + count.ToString();
    }

    public void HideLevelImage()
    {
        levelImage.SetActive(false);
    }

    public void HideLevelImageDelay(float timeDelay)
    {
        Invoke("HideLevelImage", timeDelay);
    }

    //private methods

    private void CheckInstantiation()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void FindGameObjects()
    {
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        levelOverText = GameObject.Find("LevelOverText").GetComponent<Text>();
        countText = GameObject.Find("Count Text").GetComponent<Text>();
        powerUpText = GameObject.Find("PowerUpText").GetComponent<Text>();

        levelImage = GameObject.Find("LevelImage");
        pauseText = GameObject.Find("PauseText");
    }
}
