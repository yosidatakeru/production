using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class EnemyDetectorAndShooter : MonoBehaviour
{

    public GameObject missilePrefab; // 発射する弾のプレハブ
    public Transform launchPoint; // 弾を発射する位置
    public float detectionRadius = 20f; // 検出範囲
    public LayerMask enemyLayer; // 敵のレイヤーマスク
    public int maxTargets = 10; // 最大検出する敵の数
    public GameObject markerPrefab; // 敵の位置を示す3Dモデル


    private List<Transform> detectedEnemies = new List<Transform>(); // 検出した敵リスト
    private List<GameObject> activeMarkers = new List<GameObject>(); // 配置されたマーカーのリスト
    private bool isDetecting = false; // 検出中フラグ
    private Coroutine detectionCoroutine; // 索敵用コルーチン
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // スペースキーが押されている間、敵を検出
        if (Input.GetKeyDown(KeyCode.Space) && detectionCoroutine == null)
        {
            if (!isDetecting)
            {
                isDetecting = true;
                detectionCoroutine = StartCoroutine(DetectEnemiesPeriodically());
                Debug.Log("検出を開始...");
            }

           
        }

        // スペースキーを離した瞬間に弾を発射
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (isDetecting)
            {
                if (detectionCoroutine != null)
                {
                    StopCoroutine(detectionCoroutine);
                    detectionCoroutine = null; // コルーチンを停止後、nullに設定
                    Debug.Log("検出を停止しました...");
                }
                FireMissiles();
                Debug.Log("弾を発射しました！");
            }

            // 状態をリセット
            isDetecting = false;

            // マーカーを削除
            ClearMarkers();
        }
        if (detectionCoroutine == null)
        {
            isDetecting = false;
        }
            FollowMarkers();
    }

    //マーカの処理
    private void FollowMarkers()
    {
        // 追従するマーカーの位置を更新
        for (int i = 0; i < activeMarkers.Count; i++)
        {
            if (activeMarkers[i] != null && detectedEnemies[i] != null)
            {
                // マーカーを敵の位置に追従させる
                activeMarkers[i].transform.position = detectedEnemies[i].position;
            }
            else
            {
                // 敵が倒されている場合、マーカーを削除
                if (activeMarkers[i] != null)
                {
                    Destroy(activeMarkers[i]);
                    activeMarkers.RemoveAt(i);
                    detectedEnemies.RemoveAt(i);
                    i--; // インデックスを調整
                }
            }
        }
    }

    private void ClearMarkers()
    {
        // 配置された全てのマーカーを削除
        foreach (GameObject marker in activeMarkers)
        {
            Destroy(marker);
        }
        activeMarkers.Clear();
    }



    IEnumerator DetectEnemiesPeriodically()
    {
        yield return new WaitForSeconds(2f);
        while (isDetecting)
        {
            DetectAndAddEnemy();
            yield return new WaitForSeconds(1f); // 1秒間隔で実行
        }
    }



    void DetectAndAddEnemy()
    {
        // 検出範囲内の敵を取得
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);


        if (hits.Length == 0)
        {
            Debug.Log("敵が見つかりませんでした。");
            return;  // 敵がいない場合は何もせずに終了
        }


        // 距離順に並べ替え、最も近い1体を追加（重複回避）
        Transform closestEnemy = hits
            .OrderBy(hit => Vector3.Distance(transform.position, hit.transform.position))
            .Select(hit => hit.transform)
            .FirstOrDefault();

        if (closestEnemy != null && !detectedEnemies.Contains(closestEnemy))
        {
            detectedEnemies.Add(closestEnemy);
            Debug.Log($"敵 {closestEnemy.name} を検出しました！");

        }
        else
        {
            Debug.Log("敵が見つかりませんでした。");
        }



        // マーカー数が5個を超えた場合、最も古いマーカーを削除
        if (activeMarkers.Count <= 5)
        {
            // 敵の位置にマーカーを生成
            GameObject marker = Instantiate(markerPrefab, closestEnemy.position, Quaternion.identity);
            activeMarkers.Add(marker);
        }

        // 敵を検出してリストを更新
        detectedEnemies = DetectEnemies();

        // 検出リストの最大数を超えたら削除
        if (detectedEnemies.Count > maxTargets)
        {
            detectedEnemies.RemoveAt(0);
            RemoveOldestMarker();
        }
    }

    private void RemoveOldestMarker()
    {
        // 最も古いマーカーを削除
        if (activeMarkers.Count > 0)
        {
            GameObject oldestMarker = activeMarkers[0];
            activeMarkers.RemoveAt(0);
            Destroy(oldestMarker);
        }
    }

    List<Transform> DetectEnemies()
    {

        // 検出範囲内の敵を取得
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);

        // 距離順に並べ替え、最大数だけ選択
        return hits
            .OrderBy(hit => Vector3.Distance(transform.position, hit.transform.position))
            .Take(maxTargets)
            .Select(hit => hit.transform)
            .ToList();
    }

   
    void FireMissiles()
    {
       
        // 検出した敵それぞれに弾を発射
        foreach (Transform enemy in detectedEnemies)
        {
            if (enemy != null)
            {
                // 弾を生成
                GameObject missile = Instantiate(missilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

                // ターゲットを設定（弾側に設定メソッドを用意する必要あり）
                Missile missileScript = missile.GetComponent<Missile>();
                if (missileScript != null)
                {
                    missileScript.SetTarget(enemy);
                }
            }
        }

        // 検出リストをクリア
        detectedEnemies.Clear();

      

      
        
        void OnDrawGizmosSelected()
        {
            // 検出範囲を視覚化
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }
    }
}
