using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utill
{




    /// <summary>
    /// 랜덤 포지션으로 레이캐스트
    /// </summary>
    /// <param name="_origin"> 중심위치 </param>
    /// <param name="rangeX"> x축 반경 </param>
    /// <param name="rangeZ"> z축 반경 </param>
    /// <returns>찍힌 포지션 리턴</returns>
    public static Vector3 RandomPos(Vector3 _origin, float rangeX, float rangeZ)
    {
        Vector3 origin = _origin;
        float randX = Random.Range(origin.x - rangeX, origin.x + rangeX);
        float randZ = Random.Range(origin.z - rangeZ, origin.z + rangeZ);
        origin.x = randX;
        origin.z = randZ;
        origin.y += 200f;
        int layerMask = (1 << LayerMask.NameToLayer("Terrain")) + (1 << LayerMask.NameToLayer("Item"));
        RaycastHit hitInfo;
        if (Physics.Raycast(origin, Vector3.down, out hitInfo, Mathf.Infinity, layerMask))
        {
            if (hitInfo.transform.gameObject.layer == (1 << LayerMask.NameToLayer("Item")))
                return RandomPos(_origin, rangeX, rangeZ);
            else
                return hitInfo.point;
        }
        return RandomPos(_origin, rangeX, rangeZ);
    }
    /// <summary>
    /// 오브젝트를 찾는 재귀함수
    /// </summary>
    /// <param name="_tr">최상위 오브젝트의 Transform</param>
    /// <param name="objName">찾는 오브젝트의 이름</param>
    /// <returns>존재하지 않음 = null</returns>
    public static Transform FindTransform(Transform _tr, string objName)
    {
        if (_tr.name == objName)
            return _tr;
        for (int i = 0; i < _tr.childCount; i++)
        {
            Transform findTr = FindTransform(_tr.GetChild(i), objName);
            if (findTr != null)
                return findTr;
        }
        return null;
    }
    public static Transform FindNpcTr(Transform tr)
    {
        float radius = 2f;
        float dis = 0f;
        LayerMask layer = LayerMask.NameToLayer("NPC");
        int mask = (1 << layer);
        Transform temp = null;
        Collider[] colliders =
                    Physics.OverlapSphere(tr.transform.position, radius, mask);

        foreach(Collider col in colliders)
        {
            if (temp == null)
            {
                temp = col.transform;
                dis = Vector3.Distance(tr.position, temp.position);
            }
            else
            {
                temp = dis > Vector3.Distance(tr.position, col.transform.position) ? temp : col.transform; 
            }
        }
        return temp;
    }
}
