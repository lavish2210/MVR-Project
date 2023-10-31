using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    HashSet<string> targets = new HashSet<string>();

    private void Start() {
        targets.Add("Stone");
        targets.Add("LeftGuard");
        targets.Add("RightGuard");
        targets.Add("Poles");
    }

    public float raycastDistanceStones = 30f;
    public float raycastDistanceSide = 10f;

    void Update()
    {
        bool stoneRay = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit StonehitInfo, raycastDistanceStones);

        bool SideRay = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit SidehitInfo, raycastDistanceSide) ;

        if (stoneRay && targets.Contains(StonehitInfo.collider.tag))
        {
            // Debug.Log("Ray touched " + StonehitInfo.collider.tag);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * StonehitInfo.distance, Color.red);
        }

        if (SideRay && targets.Contains(SidehitInfo.collider.tag))
        {
            // Debug.Log("Ray touched " + SidehitInfo.collider.tag);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * SidehitInfo.distance, Color.blue);
        }


    }
}
