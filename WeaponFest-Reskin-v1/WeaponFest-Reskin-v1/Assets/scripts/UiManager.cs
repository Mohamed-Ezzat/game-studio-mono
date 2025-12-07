using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    public GameObject winpanel;
    public GameObject losepanel;
    public GameObject ingame , select_weapons;
    public GameObject swipe;
    public Text level_nbr_txt;
    public Text level_nbr_win_panel;
    public Text counter , txt_mmoney;
    public GameObject money_anim;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Advertisements.Instance.Initialize();
        level_nbr_win_panel.text = level_nbr_txt.text = "LEVEL " + (GameManager.instance.getlevel() + 1);
        txt_mmoney.text = GameManager.instance.getcoin().ToString();
    }



    public void show_win()
    {
        StartCoroutine(show_win_panel());
        
    }
    public void show_lose_direct()
    {
        losepanel.SetActive(true);
        ingame.SetActive(false);

        //Advertisements.Instance.ShowInterstitial();
    }
    public void show_lose()
    {
        StartCoroutine(show_lose_panel());
    }
    IEnumerator show_lose_panel()
    {
        yield return new WaitForSeconds(2f);
        losepanel.SetActive(true);
        ingame.SetActive(false);

        Advertisements.Instance.ShowInterstitial();
    }

    IEnumerator show_win_panel()
    {
        yield return new WaitForSeconds(3f);
        winpanel.SetActive(true);
        ingame.SetActive(false);

        Advertisements.Instance.ShowInterstitial();
    }

    public void hide_swipe_panel()
    {
        FindObjectOfType<Player>().gamerun = true;

        ingame.SetActive(true);
        swipe.SetActive(false);
    }

    public void btn_retry()
    {
        Advertisements.Instance.ShowInterstitial();

        // sound
        //SoundManager.instance.Play("click");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void btn_next()
    {
        //Advertisements.Instance.ShowInterstitial();

        // sound
        //SoundManager.instance.Play("click");

        GameManager.instance.setLevel(GameManager.instance.getlevel() + 1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void counter_ui(int cnt)
    {
        counter.text = cnt.ToString();
    }

    public void instantiate_money_anim()
    {

        // game manager add money

        Destroy(Instantiate(money_anim, ingame.transform) , 2f);
    }

    public void increase_money()
    {
        GameManager.instance.setcoin(GameManager.instance.getcoin() + 5);
        txt_mmoney.text = GameManager.instance.getcoin().ToString();
    }

    public void btn_weapons()
    {
        select_weapons.SetActive(true);
        swipe.SetActive(false);
    }
}
