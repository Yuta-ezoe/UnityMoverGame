using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObject : MonoBehaviour
{
    [SerializeField]
    public Camera camera_object; //�J�������擾
    private RaycastHit hit; //���C�L���X�g�������������̂��擾������ꕨ
    private GameObject hitObject;
    private CubeMover getcube;


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //�}�E�X���N���b�N���ꂽ��
        {
            Ray ray = camera_object.ScreenPointToRay(Input.mousePosition); //�}�E�X�̃|�W�V�������擾����Ray�ɑ��

            if (Physics.Raycast(ray, out hit))  //�}�E�X�̃|�W�V��������Ray�𓊂��ĉ����ɓ���������hit�ɓ����
            {
                //string objectName = hit.collider.gameObject.name; //�I�u�W�F�N�g�����擾���ĕϐ��ɓ����
                //Debug.Log(objectName); //�I�u�W�F�N�g�����R���\�[���ɕ\��

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