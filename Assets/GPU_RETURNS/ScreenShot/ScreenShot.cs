//-----------------------------------------------------------------
// ゲーム画面のスクリーンショットを撮影する
// Unityエディタで撮影する場合、解像度はゲームビューの大きさとなる
//-----------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    // スクリーンショットを保存するフォルダ名
    string folderName = "Screenshots";

    // スクリーンショット作成中フラグ
    bool isCreatingScreenShot = false;

    // ファイルパス
    string path;

    void Start()
    {
        // Application.dataPath：
        // UnityEditaの場合はAssetsフォルダ
        // exe の場合は、プロジェクト名_Dataフォルダ
        path = Application.dataPath + "/" + folderName + "/";
    }

    void Update()
    {
        // XBoxコントローラー　左スティック押し込みでスクリーンショット撮影
        if(Input.GetButtonDown("Enable Debug Button 1"))
        {
            PrintScreen();
        }
    }

    // このメソッドを呼び出して、コルーチンをスタートさせる
    public void PrintScreen()
    {
        StartCoroutine("PrintScreenInternal");
    }

    // スクリーンショット作成コルーチン
    IEnumerator PrintScreenInternal()
    {
        // スクリーンショット作成中であればコルーチン終了
        if (isCreatingScreenShot)
        {
            yield break;
        }

        // スクリーンショット作成中フラグON
        isCreatingScreenShot = true;

        // １フレーム待機
        yield return null;

        // 指定されたパスのフォルダが無ければ作成する
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        // ファイル名を日付で作成
        string date = DateTime.Now.ToString("yy-MM-dd_HH-mm-ss");
        string fileName = path + date + ".png";

        // スクリーンショットを作成するメソッド
        // 引数：ファイルパス付きファイル名
        ScreenCapture.CaptureScreenshot(fileName);

        // スクリーンショットのファイルが出来上がるまで待機
        yield return new WaitUntil(() => File.Exists(fileName));

        // スクリーンショット作成中フラグをOFFにする
        isCreatingScreenShot = false;
    }
}