using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObject : MonoBehaviour
{
    [SerializeField]
    public Camera camera_object; //カメラを取得

    [SerializeField]
    private GameObject cubePrefabGO;

    private RaycastHit hit; //レイキャストが当たったものを取得する入れ物
    private GameObject hitObject;
    private CubeMover getcube;
    private float vecX;
    private float vecZ;


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //マウスがクリックされたら
        {
            LeftClickFunction();
        }

        if (Input.GetMouseButtonDown(1)) //マウスがクリックされたら
        {
            vecX = UnityEngine.Random.Range(-24.0f, 24.0f);
            vecZ = UnityEngine.Random.Range(-24.0f, 24.0f);
            Instantiate(cubePrefabGO, new Vector3(vecX, 0.5f, vecZ), Quaternion.identity);
        }


    }




    private void LeftClickFunction()
    {

        Ray ray = camera_object.ScreenPointToRay(Input.mousePosition); //マウスのポジションを取得してRayに代入

        if (Physics.Raycast(ray, out hit))  //マウスのポジションからRayを投げて何かに当たったらhitに入れる
        {


            // 目標物以外をクリックした場合エラースロー
            try
            {

                if (getcube == null) // コンポーネントが存在するか
                {
                    hitObject = hit.collider.gameObject;
                    getcube = hitObject.GetComponent<CubeMover>();
                    getcube.IsMoveAllow = true;
                }
                else if (hitObject.name == hit.collider.gameObject.name)
                {
                    getcube.IsMoveAllow = false;
                    getcube = null;
                }
                else
                {
                    getcube.IsMoveAllow = false;
                    hitObject = hit.collider.gameObject;
                    getcube = hitObject.GetComponent<CubeMover>();
                    getcube.IsMoveAllow = true;
                }

            }
            catch // other object touch
            {

                if (getcube != null)
                {
                    getcube.IsMoveAllow = false;
                    getcube = null;
                }
            }
        }
    }

}