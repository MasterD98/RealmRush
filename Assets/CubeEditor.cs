using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    [SerializeField][Range(1,20)] float gridsize = 10f;
    TextMesh textMesh;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 SnapPos;
        SnapPos.x = Mathf.RoundToInt(transform.position.x / gridsize) * gridsize;
        SnapPos.z = Mathf.RoundToInt(transform.position.z / gridsize) * gridsize;
        SnapPos.y = 0;
        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = SnapPos.x/gridsize + "," + SnapPos.z/gridsize;
        transform.position = SnapPos;
    }
}
