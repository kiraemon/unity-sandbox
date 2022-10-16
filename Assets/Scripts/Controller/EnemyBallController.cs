using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBallController : MonoBehaviour
{
    NavMeshAgent Player_Nav;
    GameObject Goal;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //プレイヤーのNavMeshAgentを取得
        Player_Nav = GetComponent<NavMeshAgent>();
        //目的地のオブジェクトを取得
        Goal = GameObject.Find( "Goal" );

        Player_Nav.updatePosition = false;
        Player_Nav.updateRotation = false;

        //目的地を設定
        Player_Nav.SetDestination( Goal.transform.position );
    }

    void Update()
    {
        // 次の位置への方向を求める
        var dir = Vector3.Normalize( Player_Nav.nextPosition - transform.position );

        var moveVec = 5f * new Vector3( dir.x, 0, dir.z );
        rb.AddForce( 0.5f * ( moveVec - rb.velocity ) );

        //// 方向と現在の前方との角度を計算（スムーズに回転するように係数を掛ける）
        //float smooth = Mathf.Min(1.0f, Time.deltaTime / 0.15f);
        //var angle = Mathf.Acos(Vector3.Dot(transform.forward, dir.normalized)) * Mathf.Rad2Deg * smooth;

        //// 回転軸を計算
        //var axis = Vector3.Cross(transform.forward, dir);

        //// 回転の更新
        //var rot = Quaternion.AngleAxis(angle, axis);
        //transform.forward = rot * transform.forward;

        //// 位置の更新
        //transform.position = Player_Nav.nextPosition;
    }
}