using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationsOneDoor : MonoBehaviour
{
    public TMPro.TextMeshPro text;
    public OperationType collider;
    public bool animated;
    Vector3 direction;
    public float speed;

    public SpriteRenderer sprite1;
    public Color clr1, clr2, clr3;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.right;

        generate_operation();
    }

    // Update is called once per frame
    void Update()
    {
        if (animated)
        {
            transform.Translate(direction * speed * Time.deltaTime);
            if (transform.position.x >= 15f)
                direction = Vector3.left;
            else if (transform.position.x <= 0)
                direction = Vector3.right;

        }
    }

    void generate_operation()
    {
        int rdm = Random.Range(0, 5);

        if(rdm == 0)
        {
            //increase
            int number = Random.Range(1, 50);

            text.text = "+" + number;
            collider.type = type_operation.increase;
            collider.number = number;
            sprite1.color = clr2;
        }
        else if (rdm == 1)
        {
            //decrease
            int number = Random.Range(1, 50);

            text.text = "-" + number;
            collider.type = type_operation.decrease;
            collider.number = number;
            sprite1.color = clr1;
        }
        else if (rdm == 2)
        {
            //multi
            int number = Random.Range(1, 5);

            text.text = "×" + number;
            collider.type = type_operation.multi;
            collider.number = number;
            sprite1.color = clr2;
        }
        else if (rdm == 3)
        {
            //div
            int number = Random.Range(1, 5);

            text.text = "÷" + number;
            collider.type = type_operation.div;
            collider.number = number;
            sprite1.color = clr1;
        }
        else if (rdm == 4)
        {
            //random
            random_generate(text, collider, sprite1);
        }
    }

    void random_generate(TMPro.TextMeshPro txt, OperationType op, SpriteRenderer sp)
    {
        int rdm = Random.Range(0, 4);

        if (rdm == 0)
        {
            //increase
            int number = Random.Range(1, 50);

            txt.text = "?";
            op.type = type_operation.increase;
            op.number = number;
            sp.color = clr3;
        }
        else if (rdm == 1)
        {
            //decrease
            int number = Random.Range(1, 50);

            txt.text = "?";
            op.type = type_operation.decrease;
            op.number = number;
            sp.color = clr3;
        }
        else if (rdm == 2)
        {
            //multi
            int number = Random.Range(1, 5);

            txt.text = "?";
            op.type = type_operation.multi;
            op.number = number;
            sp.color = clr3;
        }
        else if (rdm == 3)
        {
            //div
            int number = Random.Range(1, 5);

            txt.text = "?";
            op.type = type_operation.div;
            op.number = number;
            sp.color = clr3;
        }
    }
}
