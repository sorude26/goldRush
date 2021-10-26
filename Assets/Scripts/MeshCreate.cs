using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MeshCreate : MonoBehaviour
{
    [Tooltip("メッシュを生成したいオブジェクト")]
    [SerializeField] MeshFilter m_meshFilter;
    [Tooltip("メッシュの名前")]
    [SerializeField] string m_meshName = "default";
    private void Start()
    {
        CreateMesh();
    }
    /// <summary>
    /// メッシュを生成する
    /// </summary>
    public void CreateMesh()
    {
        if (m_meshName == "")
        {
            Debug.Log("ファイル名を入力してください");
            return;
        }
        if (!m_meshFilter)
        {
            Debug.Log("対象がありません");
            return;
        }
        //AssetDatabase.CreateAsset(m_meshFilter.mesh, "Assets/Material/Mesh/"+ m_meshName +".asset");
        //AssetDatabase.SaveAssets();
    }
}
