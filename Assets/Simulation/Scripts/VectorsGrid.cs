using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorsGrid : MonoBehaviour
{
    [SerializeField] private Vector vectorPrefabs;
    [SerializeField] private GameObject plane;
    [SerializeField, Range(0, 10)] private int nbVecPerLine = 1;
    [SerializeField] private FloatReference gridPositionY;
    [SerializeField] private TimeMode timeMode;
    private float planeStep = 10f;
    private float gravity = 9.81f;
    private float vectorScale = 0.2f;
    private List<Vector> vectorsInGrid;

    // Start is called before the first frame update
    void Start()
    {

    }

    public IEnumerator BuildGrid(float delay)
    {
        if (timeMode==TimeMode.Normal)
        {
            yield return new WaitForSeconds(delay);
        }
        else if (timeMode==TimeMode.UnscaledTime)
        {
            yield return new WaitForSecondsRealtime(delay);
        }

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
                newVector.components.Value = new Vector3(0, -gravity*vectorScale, 0);
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
        StartCoroutine(BuildGrid(waitingTime));
    }

    public void DestroyGrid()
    {
        StopAllCoroutines();

        if(vectorsInGrid==null)
        {return;}

        for(int i = vectorsInGrid.Count -1; i >= 0; i--)
        {
            Destroy(vectorsInGrid[i].gameObject);
            vectorsInGrid.RemoveAt(i);
        }
    }
}
