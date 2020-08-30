using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropeScriptForMenu : MonoBehaviour
{
    public Vector2 destiny;//Координаты до куда будет протягиваться верёвка
    public float speed;

    public float distance = 1;
    public GameObject nodePrefab;
    GameObject player;
    GameObject lastNode;

    public List<GameObject> Nodes = new List<GameObject>();

    int vertexCount = 2;//кол-во вершин
    [SerializeField] LineRenderer lr;

    bool done;
    void Start()
    {
        done = false;

        speed = 1;
        player = GameObject.FindGameObjectWithTag("Player");
        lastNode = transform.gameObject;

        Nodes.Add(transform.gameObject);
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destiny, speed);//Таким образом кидается верёвка
        if ((Vector2)transform.position != destiny)
        {
            if (Vector2.Distance(player.transform.position, lastNode.transform.position) > distance)
            {
                CreateNode();
            }
        } else if (done == false)
        {
            done = true;
            
            while(Vector2.Distance(player.transform.position,lastNode.transform.position) > distance)
            {
                CreateNode();
            }

            lastNode.GetComponent<HingeJoint2D>().connectedBody = player.GetComponent<Rigidbody2D>();
        }

        RenderLine();
    }

    void RenderLine()
    {
        lr.SetVertexCount(vertexCount);

        int i;
        for(i = 0;i < Nodes.Count; i++)
        {
            lr.SetPosition(i, Nodes [i].transform.position);
        }
        lr.SetPosition(i, player.transform.position);
    }


    void CreateNode()
    {
        Vector2 pos2Create = player.transform.position - lastNode.transform.position;
        pos2Create.Normalize();
        pos2Create *= distance;
        pos2Create += (Vector2)lastNode.transform.position;

        GameObject go = Instantiate(nodePrefab, pos2Create, Quaternion.identity) as GameObject;

        go.transform.SetParent(transform);

        lastNode.GetComponent<HingeJoint2D>().connectedBody = go.GetComponent<Rigidbody2D>();

        lastNode = go;

        Nodes.Add(lastNode);
        vertexCount++;
    }
}
