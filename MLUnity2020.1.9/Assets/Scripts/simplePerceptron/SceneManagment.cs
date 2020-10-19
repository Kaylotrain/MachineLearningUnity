using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class SceneManagment : MonoBehaviour
{
    public GameObject pointPrefab;
    public int nPoints;
    public float lr,depth,waitTime;
    float[] inps;
    Vector2 LeftBottom,rightTop;
    List<GameObject> points;
    Perceptron p;

    private void Awake()
    {
        points = new List<GameObject>();
        p = new Perceptron(nPoints, lr);
        inps = new float[2];
        LeftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0,0,depth));
        rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,depth));
        for (int i = 0; i < nPoints; i++)
        {
            GameObject obj = Instantiate(pointPrefab);
            initPoint(obj);
            points.Add(obj);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            rePositionPoints();
    }

    void rePositionPoints()
    {
        foreach(GameObject point in points)
        {
            initPoint(point);
        }
    }
    
    void initPoint(GameObject point)
    {
        point.transform.position = new Vector3(Random.Range(LeftBottom.x, rightTop.x), Random.Range(LeftBottom.y, rightTop.y), 2);
        if (point.transform.position.x < point.transform.position.y)
        {
            point.GetComponent<MeshRenderer>().material.color = Color.red;
            point.tag = "1";
        }
        else
        {
            point.GetComponent<MeshRenderer>().material.color = Color.blue;
            point.tag = "-1";
        }
    }

    IEnumerator checkPoints()
    {
        foreach (GameObject point in points)
        {
            inps[0] = point.transform.position.x;
            inps[1] = point.transform.position.y;
            int label = p.Predict(inps);
            int tag = int.Parse(point.tag);
            if (label == tag )
            {

            }
            else
            {

            }
            p.supervisedTrain(inps, tag);

        }
    }
}
