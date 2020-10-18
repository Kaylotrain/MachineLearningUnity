using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class SceneManagment : MonoBehaviour
{
    public GameObject pointPrefab;
    public int nPoints;
    public float lr,depth;
    Vector2 LeftBottom,rightTop;
    List<GameObject> points;
    Perceptron p;

    private void Awake()
    {
        points = new List<GameObject>();
        p = new Perceptron(nPoints, lr);

        LeftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0,0,depth));
        rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,depth));
        for (int i = 0; i < nPoints; i++)
        {
            GameObject obj = Instantiate(pointPrefab, new Vector3(Random.Range(LeftBottom.x, rightTop.x), Random.Range(LeftBottom.y, rightTop.y), 2),Quaternion.identity);
            if (obj.transform.position.x < obj.transform.position.y)
                obj.GetComponent<MeshRenderer>().material.color = Color.red;
            else
                obj.GetComponent<MeshRenderer>().material.color = Color.blue;
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
  
    }
}
