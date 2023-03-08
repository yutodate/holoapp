using UnityEngine;

public class TestGL1 : MonoBehaviour
{
    Material m_Material;                 // マテリアル
    Vector3[] m_lineVtxArray;             // ライン描画用の頂点の配列
    public Color m_lineColor = Color.blue;   // 描画色
    public Mesh m_Mesh;                     // メッシュ

    public void Start()
    {
        CreateMaterial();
        CreateVtxArray();
    }

    void OnRenderObject()
    {
        DrawLine();
    }

    // OnPostRender カメラにスクリプトをアタッチすると呼ばれた
    void OnPostRender()
    {
        //        print("OnPostRender");
    }

    // マテリアルを作成
    void CreateMaterial()
    {
        m_Material = new Material("Shader \"Lines/Color\" {" +
            "SubShader {" +
            "    Pass { " +
            "       Blend SrcAlpha OneMinusSrcAlpha" +  // αブレンド
                                                        //          "       Blend Off" +        // ブレンド オフ
            "       Cull Off" +         // カリング オフ
            "       ZWrite Off" +       // Z値の書き込み オフ
                                        //          "       ZTest Always" +     // Zテスト 常に描画
            "       ZTest Less" +       // Zテスト Z値が小さいと描画
            "       Fog { Mode Off }" + // フォグ オフ
            "       BindChannels {" +
            "           Bind \"Vertex\", vertex" +
            "           Bind \"Color\", color" +
            "       }" +
            "} } }");
        m_Material.hideFlags = HideFlags.HideAndDontSave;
        m_Material.shader.hideFlags = HideFlags.HideAndDontSave;
    }

    // メッシュから頂点の配列を作成
    void CreateVtxArray()
    {
        if (null == m_Mesh) return;

        Vector3[] vertices = m_Mesh.vertices;
        int[] triangles = m_Mesh.triangles;

        print("triangles.Length = " + triangles.Length);
        m_lineVtxArray = new Vector3[triangles.Length];
        for (int i = 0; i < triangles.Length / 3; i++)
        {
            m_lineVtxArray[i * 3 + 0] = vertices[triangles[i * 3 + 0]];
            m_lineVtxArray[i * 3 + 1] = vertices[triangles[i * 3 + 1]];
            m_lineVtxArray[i * 3 + 2] = vertices[triangles[i * 3 + 2]];
        }
    }

    // 線分の描画
    void DrawLine()
    {
        Vector3 vPos = Vector3.zero;
        Quaternion qRot = Quaternion.identity;
        Matrix4x4 mtx = Matrix4x4.TRS(vPos, qRot, Vector3.one);

        m_Material.SetPass(0);

        GL.PushMatrix();
        GL.MultMatrix(mtx);

        GL.Begin(GL.LINES);
        GL.Color(m_lineColor);

        for (int i = 0; i < m_lineVtxArray.Length / 3; i++)
        {
            GL.Vertex(m_lineVtxArray[i * 3]);
            GL.Vertex(m_lineVtxArray[i * 3 + 1]);

            GL.Vertex(m_lineVtxArray[i * 3 + 1]);
            GL.Vertex(m_lineVtxArray[i * 3 + 2]);

            GL.Vertex(m_lineVtxArray[i * 3 + 2]);
            GL.Vertex(m_lineVtxArray[i * 3]);
        }
        GL.End();
        GL.PopMatrix();
    }
}
