using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    /// <summary>
    /// インスペクターからアタッチされることを想定
    /// </summary>
    public GameObject mStartText        = null; //
    public int        mStartWaitingTime = 3;    //スタートするまでの待機時間
    
    // タイマー
    private float mTimeOut      = 1.0f;
    private float mTimeElapsed  = 0;
    private int   mTimeOutCount = 0;

    // フラグ
    private bool  mIsDisplayStart  = false; //スタート!表示をしたか

    // Start is called before the first frame update
    void Start()
    {
        if ( mStartText != null )
        {
            // 待機時間を設定
            mStartText.GetComponent<Text>().text = mStartWaitingTime.ToString();
            mStartWaitingTime++; //スタート！表記を1秒表示したいので指定より1秒分追加
            mStartText.SetActive( true );
        }
        else
        {
            Debug.LogError( "[StartManager] Error : mStartText is null." );
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ゲーム開始時しか以下の処理はされないので、
        // そもそもUpdateで呼ばないよう修正する[未実装]

        if ( mStartWaitingTime >= mTimeOutCount )
        {
            mTimeElapsed += Time.deltaTime;
        }

        if ( mTimeElapsed >= mTimeOut )
        {
            mTimeElapsed = 0f;
            mTimeOutCount++;

            // スタート表示をしている場合は表示を消すだけ
            if ( mIsDisplayStart )
            {
                mStartText.SetActive( false );
            }
            else
            {
                // 「スタート！」表示の＋１秒を加味して、
                // インスペクターで指定した秒数より小さい場合はカウントダウン、同値以上ならスタート表示
                if ( mStartWaitingTime > mTimeOutCount )
                {
                    mStartText.GetComponent<Text>().text = ( mStartWaitingTime - mTimeOutCount ).ToString();
                }
                else
                {
                    mStartText.GetComponent<Text>().text = "スタート！";
                    mIsDisplayStart = true;
                }
            }
        }
    }

    private void GameStart()
    {

    }
}
