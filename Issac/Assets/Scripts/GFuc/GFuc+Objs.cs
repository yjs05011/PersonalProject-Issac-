using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class GFunc
{

    public static void SetVelocity(Rigidbody2D rigid, float X, float Y)
    {
        rigid.velocity = new Vector2(X, Y);
    }
    public static Vector2 GetVelocity(Rigidbody2D rigid)
    {
        Vector2 getVector = new Vector2(rigid.velocity.x, rigid.velocity.y);

        return getVector;
    }

    public static GameObject GetChiled(this Transform _obj, int index)
    {
        return _obj.transform.GetChild(index).GetComponent<GameObject>();
    }
    public static RectTransform GetRect(this GameObject _obj)
    {
        return _obj.GetComponent<RectTransform>();
    }
    public static BoxCollider2D GetBoxCollider(this GameObject _obj)
    {
        return _obj.GetComponent<BoxCollider2D>();
    }
    public static Rigidbody2D GetRigid(this GameObject _obj)
    {
        return _obj.GetComponent<Rigidbody2D>();
    }
    public static void SetRotation(this RectTransform nowRect, Vector3 eulerAngle)
    {


        nowRect.rotation = Quaternion.Euler(eulerAngle);

    }
    public static void SetRotation(this RectTransform nowRect, float X, float Y, float Z)
    {


        nowRect.rotation = Quaternion.Euler(new Vector3(X, Y, Z));

    }
    public static void Direction(RectTransform Player, float x, float y)
    {
        Vector2 direction = new Vector2(Player.position.x - x, Player.position.y - y);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion angleAxis = Quaternion.AngleAxis(angle - 270f, Vector3.forward);
        Quaternion rotation = Quaternion.Slerp(Player.rotation, angleAxis, 1);
        Player.rotation = rotation;
    }
    // public static Component otherGetCommponent<T>(this GameObject other)
    // {
    //     return (other.gameObject.GetComponent<T>() as Component);
    // }
}