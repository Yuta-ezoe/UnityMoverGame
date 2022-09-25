using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObject : MonoBehaviour
{
    [SerializeField]
    public Camera camera_object; //�J�������擾

    [SerializeField]
    private GameObject cubePrefabGO;

    private RaycastHit hit; //���C�L���X�g�������������̂��擾������ꕨ
    private GameObject hitObject;
    private CubeMover getcube;
    private float vecX;
    private float vecZ;


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //�}�E�X���N���b�N���ꂽ��
        {
            LeftClickFunction();
        }

        if (Input.GetMouseButtonDown(1)) //�}�E�X���N���b�N���ꂽ��
        {
            vecX = UnityEngine.Random.Range(-24.0f, 24.0f);
            vecZ = UnityEngine.Random.Range(-24.0f, 24.0f);
            Instantiate(cubePrefabGO, new Vector3(vecX, 0.5f, vecZ), Quaternion.identity);
        }


    }




    private void LeftClickFunction()
    {

        Ray ray = camera_object.ScreenPointToRay(Input.mousePosition); //�}�E�X�̃|�W�V�������擾����Ray�ɑ��

        if (Physics.Raycast(ray, out hit))  //�}�E�X�̃|�W�V��������Ray�𓊂��ĉ����ɓ���������hit�ɓ����
        {


            // �ڕW���ȊO���N���b�N�����ꍇ�G���[�X���[
            try
            {

                if (getcube == null) // �R���|�[�l���g�����݂��邩
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