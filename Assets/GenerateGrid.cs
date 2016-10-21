using UnityEngine;
using System.Collections;

public class GenerateGrid : MonoBehaviour
{
    public GameObject tile;
    public int xSize, zSize;                    //Determines the size of the grid that will be generated.]
    public Vector3[] vertices;
    Mesh mesh;

	void Start ()
    {
        GenerateMyGrid();
	}

    // https://docs.unity3d.com/ScriptReference/Camera.ScreenPointToRay.html
    void GenerateMyGrid()
    {
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Procedural Grid";
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++, i++)
            {
                vertices[i] = new Vector3(x, 0, z);
                Instantiate(tile, vertices[i], Quaternion.identity);
            }
        }
        mesh.vertices = vertices;

        int[] triangles = new int[xSize * zSize * 6];
        for (int ti = 0, vi = 0, y = 0; y < zSize; y++, vi++)
        {
            for (int x = 0; x < xSize; x++, ti += 6, vi++)
            {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + xSize + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + 1;
                triangles[ti + 5] = vi + xSize + 2;
            }
        }
    }

    private void OnDrawGizmos()                 //Draws the grid.
    {
        if (vertices == null)
        {
            return;
        }
        Gizmos.color = Color.black;
        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], 0.1f);
        }
    }

}
