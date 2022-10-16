using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallController : MonoBehaviour
{
    /// <summary>
    /// ボールの移動スピード
    /// </summary>
    public float mMoveSpeed   = 5f;

    /// <summary>
    /// 慣性の働きの強さ（値が大きいほど慣性が働かない）
    /// </summary>
    public float mMoveInertia = 1f;

    private Rigidbody mBallRigitBody; // Rididbody

    void Start()
    {
        // ボールのRigidbody取得
        mBallRigitBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var moveHorizontal = Input.GetAxis( "Horizontal" );
        var moveVertical = Input.GetAxis( "Vertical" );

        // Ridigbodyに力を与えて玉を動かす
        // ボールの移動に関するキーが何も押されていなかったら移動量を0にする
        var moveVec = mMoveSpeed * new Vector3( moveHorizontal, 0, moveVertical );
        mBallRigitBody.AddForce( mMoveInertia * ( moveVec - mBallRigitBody.velocity ) );

        //Debug.Log( "[PlayerBall] moveHorizontal : " + moveHorizontal );
        //Debug.Log( "[PlayerBall] moveVertical : " + moveVertical );
        //Debug.Log( "[PlayerBall] moveVec : " + moveVec );
        //Debug.Log( "[PlayerBall] AddForce : " + (mMoveInertia * ( moveVec - mBallRigitBody.velocity )) );
    }
}
