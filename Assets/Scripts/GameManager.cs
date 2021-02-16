
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameIsPaused = false;
    private bool gameHasEnded = false;
    public static GameManager instance;
    public Canvas labelCanvas;

    public int totalScore;
    public Planet selectedPlanet;
    public Planet targetPlanet;
    [SerializeField]
    private Planet oldSelection;

    [Header("Inputs")]
    public bool targeting;

    [Header("Game State for Debug")]
    [SerializeField]
    private Planet[] planetArray;
    public int friendlyPlanetTotal;
    public int enemyPlanetTotal;
    public int neutralPlanetTotal;
    public GameObject pauseMenuUI;
    private PauseMenuUI pauseMenuScript;

    

    private void Awake()
    {
        Time.timeScale = 1f;
        planetArray = GetComponentsInChildren<Planet>();
        foreach (Planet p in planetArray)
        {
            if (p.faction.ToLower() == "player")
                friendlyPlanetTotal += 1;
            else if (p.faction.ToLower() == "enemy")
                enemyPlanetTotal += 1;
            else if (p.faction.ToLower() == "neutral")
                neutralPlanetTotal += 1;
        }

        pauseMenuScript = pauseMenuUI.GetComponent<PauseMenuUI>();

        

        // Uncomment below to use the one that starts in MainMenu
        // MakeSingleton();
    }



    private void Update()
    {
        HighlightHandler();

        WinLossHandler();
        
    }

    private void ShowPauseScreen(string topText)
    {

    }

    private void WinLossHandler()
    {
        if (friendlyPlanetTotal < 1)
            LoseGame();
        else if (enemyPlanetTotal < 1)
            WinGame();
        
    }

    public void Resume()
    {
        gameIsPaused = false;
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(0);
        Debug.Log("QuitToMainMenu() called, tried to load " + SceneManager.GetSceneAt(0) );
    }

    private void LoseGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            gameIsPaused = true;

            pauseMenuUI.SetActive(true);
            pauseMenuScript.setTopText("DEFEAT!");
            Time.timeScale = 0f;
        }

    }

    private void WinGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            gameIsPaused = true;

            pauseMenuUI.SetActive(true);
            pauseMenuScript.setTopText("VICTORY!");
            Time.timeScale = 0f;




            //Invoke("Restart", 2f);
        }

    }

   
    private void HighlightHandler()
    {
        if (selectedPlanet == null)
        {
            if (oldSelection != null)
            {
                foreach (Planet p in oldSelection.adjacents)
                    p.Unhighlight();

                oldSelection = null;
            }
        }
        else
        {
            if (oldSelection != selectedPlanet && oldSelection != null)
            {
                foreach (Planet p in oldSelection.adjacents)
                    p.Unhighlight();
                oldSelection = selectedPlanet;
                foreach (Planet p in selectedPlanet.adjacents)
                {
                    p.Highlight();
                }
            }
            if (targetPlanet != null && targeting == true && selectedPlanet.faction.ToLower() == "player")
            {
                selectedPlanet.MoveTroops(targetPlanet);

                targeting = false;
                selectedPlanet = null;
                targetPlanet = null;
            }
            else if (selectedPlanet != oldSelection)
            {
                oldSelection = selectedPlanet;
                foreach (Planet p in selectedPlanet.adjacents)
                {
                    p.Highlight();
                }
            }
        }
    }
    



    /*
     * Uncomment to use the MainMenu GameManager with DontDestroyOnLoad
     * 
    private void MakeSingleton()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    */

}
