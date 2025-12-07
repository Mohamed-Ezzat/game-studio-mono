using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody rb;
    CapsuleCollider cl;

    public bool active;
    public GameObject enemy1, enemy2;
    public Rigidbody[] money;
    [SerializeField] private int coinsReward = 10;

    // Start is called before the first frame update
    void Start()
    {
        active = true;
        rb = GetComponent<Rigidbody>();
        cl = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void enemy_death()
    {
        if (active)
        {
            //sound
            SoundManager.instance.Play("enemy");
            enemy1.SetActive(false);
            enemy2.SetActive(true);
            rb.isKinematic = false;

            Vector3 tmp = new Vector3(0, 2, 3);
            rb.AddForce(tmp * 10, ForceMode.Impulse);
            Destroy(gameObject, 3f);
            money_explosion();

            // NEW: Award coins via GameManager instead of old UiManager
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddCoins(coinsReward);
                Debug.Log("[Enemy] Enemy killed! Coins awarded: " + coinsReward);
            }

            active = false;
        }

    }

    public void money_explosion()
    {
        //money

        if (active)
        {
            for (int i = 0; i < money.Length; i++)
            {
                Vector3 tmp = new Vector3(Random.Range(-1, 1), Random.Range(1, 1.5f), Random.Range(-1, 1));

                money[i].gameObject.SetActive(true);
                money[i].transform.parent = null;
                money[i].isKinematic = false;
                money[i].AddForce(tmp * 2.5f, ForceMode.Impulse);

                Destroy(money[i].gameObject, 2.5f);
            }
        }

    }
}