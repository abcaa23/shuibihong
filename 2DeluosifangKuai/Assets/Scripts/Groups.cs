using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groups : MonoBehaviour
{

	// Use this for initialization
	void Start () {
        if(!isValidGridPos()){
            Debug.Log("GameOver");
        }
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += (new Vector3(-1, 0, 0));
          
            if (isValidGridPos())
            {
                updateGrid();  
            }
            else
            {
                transform.position += (new Vector3(1, 0, 0));
            }
           
                
            
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += (new Vector3(1, 0, 0));
         
            if (isValidGridPos())
            {
                updateGrid();
            }
            else
            {
                transform.position += (new Vector3(-1, 0, 0));
            }

        }

        if (isValidGridPos())
        {
            transform.Translate(0, -5 * Time.deltaTime, 0, Space.World);
            updateGrid();
        }
        else
        {
            FindObjectOfType<Spawner>().StartNext();
            enabled = false;
          
        }

 

         
        if (isValidGridPos())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.Rotate(0, 0, 90);
            }
        }
        
         
    }
 
    bool isValidGridPos()
    {
        foreach(Transform child in transform)
        {
            Vector2 v = Grid.roundVec2(child.position);
            //判断是否在边界之内(左 右 下)
            if (!Grid.insideBorder(v))
            {
                return false;
            }
            //现在grid 对应的格子是NUll
           
            if (Grid.grid[(int)v.x, (int)v.y] != null && Grid.grid[(int)v.x, (int)v.y].parent != transform)
            {
                print("12312313");
                return false;

            }
        }
        return true;
    }

    void updateGrid()
    {
        //上一次的数据清理，移去原来占据的格子信息
        for(int y = 0;y<Grid.h;y++)
            for(int x = 0; x < Grid.w; x++)
            {
                if (Grid.grid[x, y] != null)
                    if (Grid.grid[x, y].parent == transform)
                        Grid.grid[x, y] = null;
            }
        //加入本次更新的位置信息
        foreach(Transform child in transform)
        {
            Vector2 v = Grid.roundVec2(child.position);
           
            Grid.grid[(int)v.x, (int)v.y] = child;
        }
    }

}
