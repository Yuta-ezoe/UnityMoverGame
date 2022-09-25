using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObject : MonoBehaviour
{
    [SerializeField]
    public Camera camera_object; //カメラを取得
    private RaycastHit hit; //レイキャストが当たったものを取得する入れ物
    private GameObject hitObject;
    private CubeMover getcube;


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //マウスがクリックされたら
        {
            Ray ray = camera_object.ScreenPointToRay(Input.mousePosition); //マウスのポジションを取得してRayに代入

            if (Physics.Raycast(ray, out hit))  //マウスのポジションからRayを投げて何かに当たったらhitに入れる
            {
                //string objectName = hit.collider.gameObject.name; //オブジェクト名を取得して変数に入れる
                //Debug.Log(objectName); //オブジェクト名をコンソールに表示

                try
                {

                    if (getcube == null)
                    {
                        hitObject = hit.collider.gameObject;

                        getcube = hitObject.GetComponent<CubeMover>();

                        getcube.IsMoveAllow = true;
                    }
                    else if (hitObject.name == hit.collider.gameObject.name)
                    {
                        getcube.IsMoveAllow = false;
                    }
                    else
                    {

                        getcube.IsMoveAllow = false;
                        hitObject = hit.collider.gameObject;

                        getcube = hitObject.GetComponent<CubeMover>();

                        getcube.IsMoveAllow = true;

                    }

                }
                catch
                {

                    if (getcube != null)
                    {
                        getcube.IsMoveAllow = false;
                    }


                 }

                
                

            }
        }
    }
}