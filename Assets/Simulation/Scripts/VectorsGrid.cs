using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class VectorsGrid : MonoBehaviour
{
    [SerializeField] private Vector vectorPrefabs;
    [SerializeField] private GameObject plane;
    [SerializeField, Range(0, 10)] private int nbVecPerLine = 1;
    [SerializeField] private FloatReference gridPositionY;
    private float planeStep = 10f;
    private float gravity = 9.81f;
    private float vectorScale = 0.2f;
    private List<Vector> vectorsInGrid;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void BuildGrid()
    {
        float planeSizeX = plane.transform.localScale.x * planeStep;
        float planeSizeZ = plane.transform.localScale.z * planeStep;

        float spacingPerX = planeSizeX/(nbVecPerLine-1);
        float spacingPerZ = planeSizeZ/(nbVecPerLine-1);

        //Vector3 bottomLeft = plane.transform.localPosition - (plane.transform.localScale/2f * planeStep);
        Vector3 bottomLeft = plane.transform.localPosition;
        bottomLeft -= plane.transform.localScale / 2f * planeStep;
        bottomLeft.y = 0;

        vectorsInGrid = new List<Vector>();

        for (int i = 0; i < nbVecPerLine; ++i)
        {
            for (int j = 0; j < nbVecPerLine; ++j)
            {
                Vector newVector = Instantiate(vectorPrefabs, transform, false);
                newVector.transform.localPosition = bottomLeft + new Vector3(i*spacingPerX, gridPositionY.Value - 0.1f, j*spacingPerZ);
                newVector.components = new Vector3(0, -gravity*vectorScale, 0);
                newVector.sortOrder=1;
                //newVector.color = Color.green;
                newVector.SetColor();
                newVector.SetSortOrder();
                newVector.Redraw();

                vectorsInGrid.Add(newVector);

            }
        }
    }

    public void BuildGridAfterTime(float waitingTime)
    {
        Invoke("BuildGrid", waitingTime);
    }

    public void DestroyGrid()
    {
        if (vectorsInGrid==null)
        {return;}
        foreach (Vector vec in vectorsInGrid)
        {
            Destroy(vec.gameObject);
        }
    }
}
