using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed_player, horizontal_speed;
    public Rigidbody rb;
    Vector2 presspos, actualpos;
    public int counter;
    public float final_counter;
    public Car car_final;
    public bool gamerun, is_final;
    public GameObject pistols_parent;
    public List<GameObject> pistols;
    public GameObject[] weapons;
    // Start is called before the first frame update
    void Start()
    {
        instantiate_weapons();
        manage_pistols();

        counter = 1;
        rb = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        if (!gamerun)
            return;

        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, speed_player);

    }
    // Update is called once per frame
    void Update()
    {
        if (!gamerun)
            return;

        if (is_final)
        {
            final_counter -= Time.smoothDeltaTime * 100f;
            UiManager.instance.counter_ui((int)final_counter);

            if (final_counter <= 0)
            {
                rb.linearVelocity = Vector3.zero;
                gamerun = false;
                is_final = false;
                //win
                UiManager.instance.show_win();

                Bullet[] all_bullets = FindObjectsOfType<Bullet>();

                for (int i = 0; i < all_bullets.Length; i++)
                {
                    Destroy(all_bullets[i].gameObject);
                }
            }

        }
        player_movements();
    }

    void player_movements()
    {
        // ===== KEYBOARD CONTROL (ARROW KEYS) =====
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0)
        {
            Vector3 tmp = transform.position;
            tmp.x += horizontalInput * Time.deltaTime * horizontal_speed;
            tmp.x = Mathf.Clamp(tmp.x, -15, 15);
            transform.position = tmp;
        }

        // ===== MOUSE/TAP CONTROL (COMMENTED OUT) =====
        /*
        if (Input.GetMouseButtonDown(0))
        {
            presspos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            actualpos = Input.mousePosition;
            float xdiff = (actualpos.x - presspos.x) * Time.deltaTime * horizontal_speed;
            Vector3 tmp = transform.position;
            tmp.x += xdiff;
            tmp.x = Mathf.Clamp(tmp.x, -15, 15);
            transform.position = tmp;
            presspos = actualpos;
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "barrell" || other.tag == "wall")
        {
            rb.linearVelocity = Vector3.zero;
            gamerun = false;
            UiManager.instance.show_lose();
        }

        if (other.tag == "devil")
        {
            if (other.GetComponent<DevilEnemy>().active)
            {
                rb.linearVelocity = Vector3.zero;
                gamerun = false;
                other.GetComponent<DevilEnemy>().anim.Play("attack");
                UiManager.instance.show_lose();
            }

        }
        if (other.tag == "finish")
        {
            is_final = true;
            final_counter = counter;
            car_final.anim.Play("escape");
            car_final.active = true;
            Destroy(other.gameObject);
        }
        if (other.tag == "opera")
        {
            OperationType op = other.GetComponent<OperationType>();

            if (!op.active)
                return;

            if (op.type == type_operation.increase)
            {
                counter += op.number;

                pistols_visible();

                UiManager.instance.counter_ui(counter);
            }
            else if (op.type == type_operation.decrease)
            {
                counter -= op.number;
                pistols_visible();
                if (counter <= 0)
                {
                    gamerun = false;
                    rb.linearVelocity = Vector3.zero;
                    UiManager.instance.show_lose();
                    UiManager.instance.counter_ui(counter);
                }
                else
                {
                    UiManager.instance.counter_ui(counter);
                }
                // possible lose
            }
            else if (op.type == type_operation.multi)
            {
                counter *= op.number;
                pistols_visible();
                UiManager.instance.counter_ui(counter);
            }
            else if (op.type == type_operation.div)
            {
                // possible lose
                counter /= op.number;
                pistols_visible();
                if (counter <= 0)
                {
                    gamerun = false;
                    rb.linearVelocity = Vector3.zero;
                    UiManager.instance.show_lose();
                    UiManager.instance.counter_ui(counter);
                }
                else
                {
                    UiManager.instance.counter_ui(counter);
                }
            }

            op.active = false;
            if (op.other_collider != null)
            {
                op.other_collider.active = false;
            }
        }
    }

    void pistols_visible()
    {
        if (counter <= pistols.Count)
        {
            for (int i = 0; i < pistols.Count; i++)
            {
                pistols[i].transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
                pistols[i].GetComponent<Pistol>().active = false;
            }

            for (int i = 0; i < counter; i++)
            {
                pistols[i].transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
                pistols[i].GetComponent<Pistol>().active = true;
            }
        }

        else
        {

            for (int i = 0; i < pistols.Count; i++)
            {
                pistols[i].transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
                pistols[i].GetComponent<Pistol>().active = true;
            }
        }
    }

    public void manage_pistols()
    {
        for (int i = 1; i < pistols.Count; i++)
        {
            pistols[i].name = "pistol" + i;
            pistols[i].transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            pistols[i].GetComponent<Pistol>().active = false;
        }
    }

    public void instantiate_weapons()
    {
        int cnt = pistols.Count;

        for (int i = 0; i < cnt; i++)
        {
            GameObject go = Instantiate(weapons[GameManager.instance.getactivSkin()], pistols_parent.transform);
            Vector3 tmp = go.transform.localPosition;
            tmp.x = pistols[i].transform.localPosition.x;
            tmp.z = pistols[i].transform.localPosition.z;
            go.transform.localPosition = tmp;

            pistols[i] = go;
        }
    }
}
