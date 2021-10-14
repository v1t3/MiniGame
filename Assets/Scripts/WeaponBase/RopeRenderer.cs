using System;
using UnityEngine;

namespace WeaponBase
{
    public class RopeRenderer : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;

        [SerializeField] private int segments = 10;

        public void Draw(Vector3 start, Vector3 finish, float length)
        {
            lineRenderer.gameObject.SetActive(true);
            
            float interpolate = Vector3.Distance(start, finish) / length;
            float offset = Mathf.Lerp(length / 2f, 0, interpolate);

            Vector3 startDown = start + Vector3.down * offset;
            Vector3 finishDown = finish + Vector3.down * offset;

            lineRenderer.positionCount = segments + 1;

            for (int i = 0; i < segments + 1; i++)
            {
                lineRenderer.SetPosition(i, Bezier.GetPoint(start, startDown, finishDown, finish, (float)i / segments));
            }
        }

        public void Hide()
        {
            lineRenderer.gameObject.SetActive(false);
        }
    }
}