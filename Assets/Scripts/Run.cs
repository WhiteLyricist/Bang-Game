using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        //Задаём скорость передвижения.
        speed = Random.Range(2.0f, 6.0f);
        
        //Выясняем где находится объект относительно центра.
        float x = transform.position.x;
        
        //Меняем направление движения в зависимости от положения объекта.
        if (x > 0) 
        {
            speed = - speed;
            transform.Rotate(0, -180, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Перемещаем объект.
        Vector2 movement = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        transform.position = movement;

        if (transform.position.x > 10 || transform.position.x < -10) 
        {
            UIController.count--;
            Destroy(this.gameObject);
        }
    }
}
