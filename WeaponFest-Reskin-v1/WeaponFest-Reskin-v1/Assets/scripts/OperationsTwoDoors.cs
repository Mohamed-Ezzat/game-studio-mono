using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationsTwoDoors : MonoBehaviour
{
    public TMPro.TextMeshPro text_1, text_2;
    public OperationType collider1, collider2;
    public SpriteRenderer sprite1, sprite2;
    public Color clr1, clr2 , clr3;
    public bool is_start_op;
    // Start is called before the first frame update
    void Start()
    {
        if (is_start_op)
            start_operation();
        else
            generate_operation();
    }

    

    void generate_operation()
    {
        // multi increase / increase random / multi - random / multi - decrease / increase - decrease / div increase / div multi

        int rdm = Random.Range(0,7);
        int rdm2;

        //multi - increase
        if (rdm == 0)
        {
            rdm2 = Random.Range(0, 2);
            if(rdm2 == 0)
            {
                //increase
                int number = Random.Range(1, 50);

                text_1.text = "+"+number;
                collider1.type = type_operation.increase;
                collider1.number = number;
                sprite1.color = clr2;

                // multi 
                number = Random.Range(1, 5);

                text_2.text = "×" + number;
                collider2.type = type_operation.multi;
                collider2.number = number;
                sprite2.color = clr2;
            }
            else
            {
                //increase
                int number = Random.Range(1, 50);

                text_2.text = "+" + number;
                collider2.type = type_operation.increase;
                collider2.number = number;
                sprite2.color = clr2;

                // multi 
                number = Random.Range(1, 5);

                text_1.text = "×" + number;
                collider1.type = type_operation.multi;
                collider1.number = number;
                sprite1.color = clr2;
            }
        }
        // increase - random
        else if (rdm == 1)
        {
            rdm2 = Random.Range(0, 2);
            if (rdm2 == 0)
            {
                //increase
                int number = Random.Range(1, 50);

                text_1.text = "+" + number;
                collider1.type = type_operation.increase;
                collider1.number = number;
                sprite1.color = clr2;

                // random ...... 
                random_generate(text_2, collider2, sprite2);
            }
            else
            {
                //increase
                int number = Random.Range(1, 50);

                text_2.text = "+" + number;
                collider2.type = type_operation.increase;
                collider2.number = number;
                sprite2.color = clr2;

                // random ...... 
                random_generate(text_1, collider1, sprite1);
            }
        }
        // multi - random
        else if (rdm == 2)
        {
            rdm2 = Random.Range(0, 2);
            if (rdm2 == 0)
            {
                //multi
                int number = Random.Range(1, 5);

                text_1.text = "×" + number;
                collider1.type = type_operation.multi;
                collider1.number = number;
                sprite1.color = clr2;

                // random ...... 
                random_generate(text_2, collider2, sprite2);
            }
            else
            {
                //multi
                int number = Random.Range(1, 5);

                text_2.text = "×" + number;
                collider2.type = type_operation.multi;
                collider2.number = number;
                sprite2.color = clr2;

                // random ...... 
                random_generate(text_1, collider1, sprite1);
            }
        }
        //multi - decrease
        if (rdm == 3)
        {
            rdm2 = Random.Range(0, 2);
            if (rdm2 == 0)
            {
                //decrease
                int number = Random.Range(1, 50);

                text_1.text = "-" + number;
                collider1.type = type_operation.decrease;
                collider1.number = number;
                sprite1.color = clr1;

                // multi 
                number = Random.Range(1, 5);

                text_2.text = "×" + number;
                collider2.type = type_operation.multi;
                collider2.number = number;
                sprite2.color = clr2;
            }
            else
            {
                //decrease
                int number = Random.Range(1, 50);

                text_2.text = "-" + number;
                collider2.type = type_operation.decrease;
                collider2.number = number;
                sprite2.color = clr1;

                // multi 
                number = Random.Range(1, 5);

                text_1.text = "×" + number;
                collider1.type = type_operation.multi;
                collider1.number = number;
                sprite1.color = clr2;
            }
        }
        //decrease - increase
        if (rdm == 4)
        {
            rdm2 = Random.Range(0, 2);
            if (rdm2 == 0)
            {
                //decrease
                int number = Random.Range(1, 50);

                text_1.text = "-" + number;
                collider1.type = type_operation.decrease;
                collider1.number = number;
                sprite1.color = clr1;

                // increase 
                number = Random.Range(1, 50);

                text_2.text = "+" + number;
                collider2.type = type_operation.increase;
                collider2.number = number;
                sprite2.color = clr2;
            }
            else
            {
                //decrease
                int number = Random.Range(1, 50);

                text_2.text = "-" + number;
                collider2.type = type_operation.decrease;
                collider2.number = number;
                sprite2.color = clr1;

                // increase 
                number = Random.Range(1, 50);

                text_1.text = "+" + number;
                collider1.type = type_operation.increase;
                collider1.number = number;
                sprite1.color = clr2;
            }
        }
        //div - increase
        if (rdm == 5)
        {
            rdm2 = Random.Range(0, 2);
            if (rdm2 == 0)
            {
                //div
                int number = Random.Range(1, 5);

                text_1.text = "÷" + number;
                collider1.type = type_operation.div;
                collider1.number = number;
                sprite1.color = clr1;

                // increase 
                number = Random.Range(1, 50);

                text_2.text = "+" + number;
                collider2.type = type_operation.increase;
                collider2.number = number;
                sprite2.color = clr2;
            }
            else
            {
                //div
                int number = Random.Range(1, 5);

                text_2.text = "÷" + number;
                collider2.type = type_operation.div;
                collider2.number = number;
                sprite2.color = clr1;

                // increase 
                number = Random.Range(1, 50);

                text_1.text = "+" + number;
                collider1.type = type_operation.increase;
                collider1.number = number;
                sprite1.color = clr2;
            }
        }
        //multi - div
        if (rdm == 6)
        {
            rdm2 = Random.Range(0, 2);
            if (rdm2 == 0)
            {
                //div
                int number = Random.Range(1, 5);

                text_1.text = "÷" + number;
                collider1.type = type_operation.div;
                collider1.number = number;
                sprite1.color = clr1;

                // multi 
                number = Random.Range(1, 5);

                text_2.text = "×" + number;
                collider2.type = type_operation.multi;
                collider2.number = number;
                sprite2.color = clr2;
            }
            else
            {
                //div
                int number = Random.Range(1, 5);

                text_2.text = "÷" + number;
                collider2.type = type_operation.div;
                collider2.number = number;
                sprite2.color = clr1;

                // multi 
                number = Random.Range(1, 5);

                text_1.text = "×" + number;
                collider1.type = type_operation.multi;
                collider1.number = number;
                sprite1.color = clr2;
            }
        }
    }

    void random_generate(TMPro.TextMeshPro txt , OperationType op , SpriteRenderer sp)
    {
        int rdm = Random.Range(0, 4);

        if(rdm == 0)
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

    void start_operation()
    {
        int rdm2 = Random.Range(0, 2);
        if (rdm2 == 0)
        {
            //increase
            int number = Random.Range(1, 25);

            text_1.text = "+" + number;
            collider1.type = type_operation.increase;
            collider1.number = number;
            sprite1.color = clr2;

            // multi 
            number = Random.Range(1, 5);

            text_2.text = "×" + number;
            collider2.type = type_operation.multi;
            collider2.number = number;
            sprite2.color = clr2;
        }
        else
        {
            //increase
            int number = Random.Range(1, 25);

            text_2.text = "+" + number;
            collider2.type = type_operation.increase;
            collider2.number = number;
            sprite2.color = clr2;

            // multi 
            number = Random.Range(1, 5);

            text_1.text = "×" + number;
            collider1.type = type_operation.multi;
            collider1.number = number;
            sprite1.color = clr2;
        }
    }
}
