using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _4d_parser;
using System.IO;

[ExecuteInEditMode]
public class _4DObject : MonoBehaviour
{

    public MeshFilter _MeshFilter;
    [HideInInspector] public MeshCollider _MeshCollider;
    public string path; 
    string oldpath;
    int w;
    [Range(0,1)]
    public float _3Dlayer;
    public float w_scale = 1;
    int pw;
    format_4d f4 = new format_4d();
    [HideInInspector] public Vector3[] verti;
    [HideInInspector] public int[] tria;
    Mesh[] m = new Mesh[0];
    UnityEngine.Rendering.MeshUpdateFlags m3 = UnityEngine.Rendering.MeshUpdateFlags.Default;
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<MeshCollider>())
        {
            _MeshCollider = GetComponent<MeshCollider>();
        }


        _MeshFilter = GetComponent<MeshFilter>();
        
        f4.load(path);
      m = new Mesh[f4.objs.Count];
        Directory.CreateDirectory("frame3d");
        for (int i =0; i<m.Length;i++)
        {


            File.WriteAllText("frame3d/1" + gameObject.GetInstanceID(), f4.objs[i].objstring);
            m[i] = charge("frame3d/1" + gameObject.GetInstanceID());
        }
    }

    private Mesh charge(string modelhash)
    {
        ObjParser.Obj newobj = new ObjParser.Obj();
        newobj.LoadObj(modelhash);
        var mesh = new Mesh();
        mesh.name = "cube";
        Vector3[] vertices = new Vector3[newobj.VertexList.Count];
        List<Vector2> uv = new List<Vector2>();
        List<int> triangles = new List<int>();
        for (int i = 0; i < newobj.VertexList.Count; i++)
        {
            vertices[i] = new Vector3((float)newobj.VertexList[i].X, (float)newobj.VertexList[i].Y, (float)newobj.VertexList[i].Z);

            uv.Add(new Vector2((float)newobj.TextureList[i].X, (float)newobj.TextureList[i].Y));


        }

        for (int f = 0; f < newobj.FaceList.Count; f ++)
        {
           
            for (int i = 0; i < newobj.FaceList[f].VertexIndexList.Length; i ++)
            {



                triangles.Add(newobj.FaceList[f].VertexIndexList[(i)] - 1);




            }
        }
        

        
       tria = triangles.ToArray();
            verti = vertices;
        mesh.SetVertices(vertices);
        mesh.triangles = triangles.ToArray();
        mesh.uv = uv.ToArray();
        mesh.RecalculateNormals(m3);
        
        return mesh;
    }
    void reload()
    {
        if (GetComponent<MeshCollider>())
        {
            _MeshCollider = GetComponent<MeshCollider>();
        }
        f4 = new format_4d();
        f4.load(path);
        m = new Mesh[f4.objs.Count];
        Directory.CreateDirectory("frame3d");
        for (int i = 0; i < m.Length; i++)
        {


            File.WriteAllText("frame3d/1" + gameObject.GetInstanceID(), f4.objs[i].objstring);
            m[i] = charge("frame3d/1" + gameObject.GetInstanceID());
        }
    }

    // Update is called once per frame
    void Update()
    {

        float wmax = f4.objs.Count;
        w = (int)(_3Dlayer * (int)wmax);
        if (w != pw)
        {

            
            if (w > -1 && w < f4.objs.Count-1)
            {
                
                _MeshFilter.mesh = m[w];
                if (_MeshCollider) {
                    _MeshCollider.sharedMesh = m[w];
                }
            }
            
            pw = w;
        }

        if (oldpath != path)
        {
            reload(); if (m.Length > w)
            {


                _MeshFilter.mesh = m[w];
            }
            if (_MeshCollider)
            {
                _MeshCollider.sharedMesh = m[w];
            }

            oldpath = path;
        }

    }
}
