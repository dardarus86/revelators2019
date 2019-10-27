using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Canvas quitMenu;
    public Button startText;
    //public Button controlsText;
    public Button exitText;

    private void Start()
    {
        quitMenu = quitMenu.GetComponent<Canvas>();
        //controlsText = controlsText.GetComponent<Button>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        quitMenu.enabled = false;
    }

    public void ExitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        //controlsText.enabled = false;
        exitText.enabled = false;
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
