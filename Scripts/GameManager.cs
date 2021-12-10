using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int score = 0;
    public int lives = 3;
    public int level = 1;
    public int maxLevels = 3;

    const int NUM_LEVELS_ORIGINAL = 2; //for original DO NOT CHANGE

    public Ball ball { get; private set; }
    public Paddle paddle { get; private set; }
    public Brick[] bricks { get; private set; }

    public OldBrick[] oldBricks { get; private set; }

    public Scoring scoreManager { get; private set; }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    private void Start()
    {
        SceneManager.LoadScene("TitleScreen");
    }


    public void NewGame()
    {
        this.score = 0;
        this.lives = 3;

        LoadLevelNew(1);
    }

    public void LoadOriginal()
    {
        this.score = 0;
        this.lives = 3;

        LoadLevelOriginal(1);
    }

    private void LoadLevelNew(int level)
    {
        this.level = level;

        SceneManager.LoadScene("NewLevel" + level);
    }

    private void LoadLevelOriginal(int level)
    {
        this.level = level;

        if (level > NUM_LEVELS_ORIGINAL)
        {
            // Start over again at level 1 once you have beaten all the levels
            // You can also load a "Win" scene instead
            LoadLevelOriginal(1);
            return;
        }

        SceneManager.LoadScene("OriLevel" + level);
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        this.ball = FindObjectOfType<Ball>();
        this.paddle = FindObjectOfType<Paddle>();
        this.bricks = FindObjectsOfType<Brick>();
        this.oldBricks = FindObjectsOfType<OldBrick>();
        this.scoreManager = FindObjectOfType<Scoring>();
    }

    public void HitNew(Brick brick)
    {
        this.score += brick.points;
        scoreManager.changeScore();
        if (ClearedNew())
        {
            if(this.level < maxLevels)
            {
                LoadLevelNew(this.level + 1);
            }
            else
            {
                SceneManager.LoadScene("WinScreen");
            }
        }
    }

    public void HitOld(OldBrick brick)
    {
        this.score += brick.points;

        if (ClearedOld())
        {
            if (this.level <= NUM_LEVELS_ORIGINAL)
            {
                LoadLevelOriginal(this.level + 1);
            }
        }
    }

    public void MissNew()
    {
        this.lives--;
        scoreManager.changeScore();
        if (this.lives > 0)
        {
            ResetLevel();
        }
        else
        {
            GameOverNew();
        }
    }

    public void MissOri()
    {
        this.lives--;
        if (this.lives > 0)
        {
            ResetLevel();
        }
        else
        {
            GameOverOri();
        }
    }

    private void GameOverNew()
    {
        SceneManager.LoadScene("GameOver");
    }

    private void GameOverOri()
    {
        // Start a new game immediately
        // You can also load a "GameOver" scene instead
        LoadOriginal();
    }

    private void ResetLevel()
    {
        this.ball.ResetBall();
        this.paddle.ResetPaddle();
        //for(int i = 0; i < this.bricks.Length; i++)
        //{
        //    this.bricks[i].ResetBrick();
        //}
    }

    public bool ClearedNew()
    {
        for(int i = 0; i < this.bricks.Length; i++)
        {
            if (this.bricks[i].gameObject.activeInHierarchy && !this.bricks[i].unbreakable)
            {
                return false;
            }
        }
        return true;
    }
    public bool ClearedOld()
    {
        for (int i = 0; i < this.oldBricks.Length; i++)
        {
            if (this.oldBricks[i].gameObject.activeInHierarchy && !this.oldBricks[i].unbreakable)
            {
                return false;
            }
        }
        return true;
    }
}
