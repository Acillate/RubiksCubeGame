using System.Collections;
using System.Collections.Generic;
//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class CubeMap : MonoBehaviour
{
    CubeState cubeState;
    public Transform up;
    public Transform down;
    public Transform left;
    public Transform right;
    public Transform front;
    public Transform back;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void set(){
        cubeState = FindObjectOfType<CubeState>();
        updateMap(cubeState.front, front);
        updateMap(cubeState.back, back);
        updateMap(cubeState.left, left);
        updateMap(cubeState.right, right);
        updateMap(cubeState.up, up);
        updateMap(cubeState.down, down);

    }
    void updateMap(List<GameObject> face, Transform side){
        int i = 0;
        foreach(Transform map in side){
            if(face[i].name[0] == 'F'){
                map.GetComponent<Image>().color = Color.red;
            }
            if(face[i].name[0] == 'B'){
                map.GetComponent<Image>().color = new Color(1, 0.5f, 0, 1);
            }
            if(face[i].name[0] == 'U'){
                map.GetComponent<Image>().color = Color.yellow;
            }
            if(face[i].name[0] == 'D'){
                map.GetComponent<Image>().color = Color.green;
            }
            if(face[i].name[0] == 'L'){
                map.GetComponent<Image>().color = Color.blue;
            }
            if(face[i].name[0] == 'R'){
                map.GetComponent<Image>().color = Color.white;
            }
            i++;
        }
    }
}
