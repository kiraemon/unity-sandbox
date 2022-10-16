using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalManager : MonoBehaviour
{
    /// <summary>
    /// インスペクターからアタッチされることを想定
    /// </summary>
    public GameObject mGoalText = null;

    // 内部フラグ
    private bool mIsAnyGoal = false; // 誰かがゴールしたか？
        
    void Start()
    {
        if ( mGoalText != null )
        {
            mGoalText.SetActive( false );
        }
        else
        {
            Debug.LogError( "[GoalManager] Error : mGoalText is null" );
        }
    }
    
    void Update()
    {
        
    }

    private void OnTriggerEnter( Collider other )
    {
        if ( mGoalText != null )
        {
            mGoalText.SetActive( true );
        }
        else
        {
            Debug.LogError( "[GoalManager] Error : mGoalText is null" );
        }

        mIsAnyGoal = true;
    }
}
