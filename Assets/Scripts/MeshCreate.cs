using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MeshCreate : MonoBehaviour
{
    [Tooltip("���b�V���𐶐��������I�u�W�F�N�g")]
    [SerializeField] MeshFilter m_meshFilter;
    [Tooltip("���b�V���̖��O")]
    [SerializeField] string m_meshName = "default";
    private void Start()
    {
        CreateMesh();
    }
    /// <summary>
    /// ���b�V���𐶐�����
    /// </summary>
    public void CreateMesh()
    {
        if (m_meshName == "")
        {
            Debug.Log("�t�@�C��������͂��Ă�������");
            return;
        }
        if (!m_meshFilter)
        {
            Debug.Log("�Ώۂ�����܂���");
            return;
        }
        //AssetDatabase.CreateAsset(m_meshFilter.mesh, "Assets/Material/Mesh/"+ m_meshName +".asset");
        //AssetDatabase.SaveAssets();
    }
}
