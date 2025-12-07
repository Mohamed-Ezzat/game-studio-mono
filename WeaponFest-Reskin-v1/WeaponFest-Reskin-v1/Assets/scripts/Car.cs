using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Rigidbody[] money;
    public Rigidbody[] car_parts;

    public int number;
    public Animator anim;
    public float speed;
    public bool active;
    public Transform pos;
    public TMPro.TextMeshPro text;

    // Start is called before the first frame update
    void Start()
    {
        number = Random.Range(140, 220);
        text.text = number.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if (transform.position.z >= pos.position.z)
            {
                active = false;
                anim.Play("lost");

                Player pl_script = FindObjectOfType<Player>();
                pl_script.gamerun = false;
                pl_script.rb.linearVelocity = Vector3.zero;

                UiManager.instance.show_win();
            }
        }
    }

    public void decrease_car()
    {
        if (!active)
            return;

        if (number <= car_parts.Length)
        {
            Vector3 tmp = new Vector3(Random.Range(-2, 2), Random.Range(1, 3), Random.Range(-5, 5));

            car_parts[number - 1].isKinematic = false;
            car_parts[number - 1].AddForce(tmp * 40, ForceMode.Impulse);

            Destroy(car_parts[number - 1].gameObject, 3f);
        }

        if (number != 1)
        {
            number--;
            text.text = number.ToString();
        }
        
        else
        {
            active = false;

            text.gameObject.SetActive(false);

            anim.Play("explosion");

            //sound
            SoundManager.instance.Play("car_explosion");

            Player pl_script = FindObjectOfType<Player>();
            pl_script.gamerun = false;
            pl_script.rb.linearVelocity = Vector3.zero;

            //money
            for (int i = 0; i < money.Length; i++)
            {
                Vector3 tmp = new Vector3(Random.Range(-2, 2), Random.Range(1, 2), Random.Range(-5, 5));

                money[i].isKinematic = false;
                money[i].AddForce(tmp * 15, ForceMode.Impulse);
            }
            // win
            UiManager.instance.show_win();
        }
    }
}
