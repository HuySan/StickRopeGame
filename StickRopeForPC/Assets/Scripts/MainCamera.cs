 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    /// <summary>
    /// Скрипт ждёт лучших времён
    /// </summary>
    

    public float dumping = 1.5f;//отвечает за сглаживание камеры
    public Vector2 offset = new Vector2(2f, 1f);//смещение относитенльнл перса
    public bool isLeft;//проверка на взгляд влево
    private Transform player;
    private int lastX;//в какую сторону последний раз смотрел перс

    void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);//вычисление смещения
        FindPlayer(isLeft);
    }

    void FindPlayer(bool playerIsLeft)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastX = Mathf.RoundToInt(player.position.x);//позволяет работать по оси x
        if (playerIsLeft)
        {
            transform.position = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);//если перс смотрит влево,то смещается камера относительно перса,вычитая смещение по x и y
        }
        else
        {
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);//смотри вправо...
        }
    }

    void Update()
    {
        transform.rotation = Quaternion.identity;
        if (player)
        {
            int currentX = Mathf.RoundToInt(player.position.x);//счиьывание положение камеры по x относительно перса
            if (currentX > lastX) isLeft = false; else if (currentX < lastX) isLeft = true;
            lastX = Mathf.RoundToInt(player.position.x);

            Vector3 target;
            if (isLeft)
            {
                target = new Vector3(player.position.x - offset.x, player.position.y + offset.y, transform.position.z);
            }
            else
            {
                target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
            }

            Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
            transform.position = currentPosition;
                }
    }
}
