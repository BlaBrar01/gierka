using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextAnimator : MonoBehaviour
{
    Mesh mesh;
    TMP_Text textMesh;
    Vector3[] vertices;
    void Start()
    {
        textMesh = GetComponent<TMP_Text>();
    }
    void Update()
    {
        textMesh.ForceMeshUpdate();
        mesh = textMesh.mesh;
        vertices = mesh.vertices;
    }
}
