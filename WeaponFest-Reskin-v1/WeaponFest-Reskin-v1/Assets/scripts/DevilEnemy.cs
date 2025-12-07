using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilEnemy : MonoBehaviour
{
    Rigidbody rb;
    public bool active;
    public int number;
    public TMPro.TextMeshPro text;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        active = true;
        number = Random.Range(100, 200);
        text.text = number.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enemy_death()
    {
        if (number != 1)
        {
            number--;
            text.text = number.ToString();
        }

        else
        {
            if (active)
            {
                rb.isKinematic = false;
                text.gameObject.SetActive(false);
                Vector3 tmp = new Vector3(0, 2, 3);
                anim.Play("death");
                rb.AddForce(tmp * 12, ForceMode.Impulse);
                Destroy(gameObject, 3f);
                active = false;
            }
        }
        
    }
}
