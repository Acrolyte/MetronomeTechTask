using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Generator : MonoBehaviour
{
    //private int[,] mat = new int[5, 5];
    public Child[] children;
    
        
    private void Start()
    {
        children = gameObject.GetComponentsInChildren<Child>();
        //Array.Sort(children, index);
        Array.Sort<Child>(children , new Comparison<Child>((i1, i2) => i1.index.CompareTo(i2.index)));
        //foreach( var children[i] in children)
        for(int i=0;i<children.Length;i++)
        {
            //ref Child children[i] = ref children[i];
            Debug.Log($"{children[i].gameObject.name}");
            children[i].axis = UnityEngine.Random.Range(0,2)==0 ? 'x':'z';
            children[i].unit = UnityEngine.Random.Range(-1, 2);
            int index = children[i].index;
            if(index==2)
            {
                if(children[i].unit==-1)
                {
                    children[i].unit = 0;
                }
            }
            if(index==0)
            {
                if((children[i].axis=='z' && children[i].unit==-1)|| (children[i].axis=='x' && children[i].unit==1))
                {
                    children[i].unit = 0;

                }
            }
            if (index == 8)
            {
                if ((children[i].axis == 'z' && children[i].unit == 1) || (children[i].axis == 'x' && children[i].unit == -1))
                {
                    children[i].unit = 0;

                }
            }
            if (index == 6)
            {
                if (children[i].unit == 1)
                {
                    children[i].unit = 0;
                }
            }

            if(index == 1 && children[i].axis == 'z' && children[i].unit == -1)
            {
                children[i].unit = 0;
            }
            if (index == 5 && children[i].axis == 'x' && children[i].unit == -1)
            {
                children[i].unit = 0;
            }
            if (index == 7 && children[i].axis == 'z' && children[i].unit == 1)
            {
                children[i].unit = 0;
            }
            if (index == 3 && children[i].axis == 'x' && children[i].unit == 1)
            {
                children[i].unit = 0;
            }

            if (children[i].axis == 'x' && children[i].unit != 0)
            {
                children[i].transform.localScale = new Vector3(children[i].unit * 2, 1, 1);
                children[i].transform.localPosition = new Vector3(children[i].transform.localPosition.x + children[i].unit * 0.5f, children[i].transform.localPosition.y, children[i].transform.localPosition.z);
            }

            if (children[i].axis == 'z' && children[i].unit != 0)
            {
                children[i].transform.localScale = new Vector3(1, 1, children[i].unit * 2);
                children[i].transform.localPosition = new Vector3(children[i].transform.localPosition.x, children[i].transform.localPosition.y, children[i].transform.localPosition.z + children[i].unit * 0.5f);
            }

            //children[i].makeObject();
        }

        bool[] vis = new bool[9];
        for(int i=0;i<children.Length;i++)
        {
            if(vis[i]==true)
            {
                Debug.Log(children[i].name.ToString() + "is destroyed");
                Destroy(children[i].gameObject);
                continue;
            }
            vis[i] = true;
            if(children[i].unit != 0)
            {
                int index = children[i].index;
                switch (index)
                {
                    case 0:
                        if (children[i].axis == 'z') vis[3] = true;
                        else if (children[i].axis == 'x') vis[1] = true;
                        break;
                    case 1:
                        if (children[i].axis == 'z') vis[4] = true;
                        else if (children[i].axis == 'x')
                        {
                            if (children[i].unit == -1) vis[2] = true;
                            else if (children[i].unit == 1) vis[0] = true;
                        }
                        break;
                    case 2:
                        if (children[i].axis == 'z') vis[5] = true;
                        else if (children[i].axis == 'x') vis[1] = true;
                        break;
                    case 3:
                        if (children[i].axis == 'x') vis[4] = true;
                        else if (children[i].axis == 'z')
                        {
                            if (children[i].unit == -1) vis[0] = true;
                            else if (children[i].unit == 1) vis[6] = true;
                        }
                        break;
                    case 4:
                        if (children[i].axis == 'x')
                        {
                            if (children[i].unit == -1) vis[5] = true;
                            else if (children[i].unit == 1) vis[3] = true;
                        }
                        else if (children[i].axis == 'z')
                        {
                            if (children[i].unit == -1) vis[1] = true;
                            else if (children[i].unit == 1) vis[7] = true;
                        }
                        break;
                    case 5:
                        if (children[i].axis == 'x') vis[4] = true;
                        if (children[i].axis == 'z' && children[i].unit == 1) vis[8] = true;
                        if (children[i].axis == 'z' && children[i].unit == -1) vis[2] = true;
                        break;
                    case 6:
                        if (children[i].axis == 'x') vis[7] = true;
                        if (children[i].axis == 'z') vis[3] = true;
                        break;
                    case 7:
                        if (children[i].axis == 'x' && children[i].unit == 1) vis[6] = true;
                        if (children[i].axis == 'x' && children[i].unit == -1) vis[8] = true;
                        if (children[i].axis == 'z') vis[4] = true;
                        break;
                    case 8:
                        if (children[i].axis == 'x') vis[7] = true;
                        if (children[i].axis == 'z') vis[5] = true;
                        break;
                    default:
                        break;
                }
            }
        }


        for(int i = 0; i < children.Length; i++)
        {
            if (children[i].unit == 0)
            {
                children[i].GetComponent<Renderer>().material.color = Color.white;
            }
            else children[i].GetComponent<Renderer>().material.color = Color.red;
        }
        //  (0, 1, 2)->no top
        //  (0, 3, 6)->no left
        //  6,7,8->no bottom
        //  2,5,8->no right

    }


}
