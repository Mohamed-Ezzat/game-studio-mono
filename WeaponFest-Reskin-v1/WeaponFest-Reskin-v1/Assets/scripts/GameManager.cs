
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        onstartfirsttime();


    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            setcoin(5000);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            resetall();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            //setLevel(getlevel() + 1);
            //if (levels.Length <= getlevel() + 1)
            //    return;
            setLevel(getlevel() + 1);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void onstartfirsttime()
    {
        if (!PlayerPrefs.HasKey("firsttime_genaral"))
        {
            PlayerPrefs.SetInt("level_general", 0);
            PlayerPrefs.SetInt("firsttime_genaral", 0);
            PlayerPrefs.SetInt("devil", 0);
            PlayerPrefs.SetInt("coin", 0);
            PlayerPrefs.SetInt("skin0", 1);
            PlayerPrefs.SetInt("activSkin", 0);
            PlayerPrefs.SetInt("count", 1);
        }
    }

    //level
    public void setLevel(int lv)
    {
        PlayerPrefs.SetInt("level_general", lv);
    }
    public int getlevel()
    {
        return PlayerPrefs.GetInt("level_general");
    }

    // reset
    public void resetall()
    {
        PlayerPrefs.DeleteKey("firsttime_genaral");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //level
    public void set_devil_count(int dv)
    {
        PlayerPrefs.SetInt("devil", dv);
    }
    public int get_devil_count()
    {
        return PlayerPrefs.GetInt("devil");
    }

    // coin
    public int getcoin()
    {
        return PlayerPrefs.GetInt("coin");
    }
    public void setcoin(int nbr)
    {
        PlayerPrefs.SetInt("coin", nbr);
    }

    //skin variables

    public void setskin(int numSkin, int active)
    {
        PlayerPrefs.SetInt("skin" + numSkin, active);
    }

    public int getskin(int numSkin)
    {
        return PlayerPrefs.GetInt("skin" + numSkin);
    }

    // active skin

    public void setactivSkin(int activSkin)
    {
        PlayerPrefs.SetInt("activSkin", activSkin);
    }

    public int getactivSkin()
    {
        return PlayerPrefs.GetInt("activSkin");
    }

    // count Active skin
    public int getcountActive()
    {
        return PlayerPrefs.GetInt("count");
    }
    public void setcountActive(int nbr)
    {
        PlayerPrefs.SetInt("count", nbr);
    }
}
