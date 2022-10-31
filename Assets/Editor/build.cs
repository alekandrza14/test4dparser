using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEditor.Callbacks;
using System.IO;
using UnityEditor.Build;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class ScriptBatch
{
    static int mainversion = 0; static int neoversion = 1; static int version = 0;
    [MenuItem("Build/Default")]
    public static void BuildGame()
    {

        string path = EditorUtility.SaveFolderPanel("Choose Location of Built Game", "", "");
        clear(path);
        List<string> levels = new List<string>();

        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            EditorBuildSettingsScene[] s = EditorBuildSettings.scenes;
            levels.Add(s[i].path);
        }


        BuildPipeline.BuildPlayer(levels.ToArray(), path + "/NameApplication" + ".exe", BuildTarget.StandaloneWindows64, BuildOptions.None);

        if (!File.Exists(path + "/resourses"))
        {
            FileUtil.CopyFileOrDirectory("resourses", path + "/resourses");
        }



    }
    [MenuItem("Build/Default+run")]
    public static void BuildGame1()
    {

        string path = EditorUtility.SaveFolderPanel("Choose Location of Built Game", "", "");
        clear(path);
        List<string> levels = new List<string>();

        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            EditorBuildSettingsScene[] s = EditorBuildSettings.scenes;
            levels.Add(s[i].path);
        }

        // 1-й имя вашей игры 2-й формат файла запуска игры
        BuildPipeline.BuildPlayer(levels.ToArray(), path + "/NameApplication" + ".exe", BuildTarget.StandaloneWindows64, BuildOptions.None);
        //папка моделей
        if (!File.Exists(path + "/resourses"))
        {
            FileUtil.CopyFileOrDirectory("resourses", path + "/resourses");
        }
        Process proc = new Process();
        proc.StartInfo.FileName = path + "/NameApplication" + ".exe";
        proc.Start();


    }
    [MenuItem("Build/32")]
    public static void BuildGame2()
    {

        string path = EditorUtility.SaveFolderPanel("Choose Location of Built Game", "", "");
        clear(path);
        List<string> levels = new List<string>();

        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            EditorBuildSettingsScene[] s = EditorBuildSettings.scenes;
            levels.Add(s[i].path);
        }


        BuildPipeline.BuildPlayer(levels.ToArray(), path + "/NameApplication" + ".exe", BuildTarget.StandaloneWindows, BuildOptions.None);

        if (!File.Exists(path + "/resourses"))
        {
            FileUtil.CopyFileOrDirectory("resourses", path + "/resourses");
        }



    }
    public static void clear(string path)
    {
        if (path != Application.dataPath)
        {
            

                Directory.Delete(path, true);
                Directory.CreateDirectory(path);
            
        }
    }
    [MenuItem("Build/32+run")]
    public static void BuildGame3()
    {

        string path = EditorUtility.SaveFolderPanel("Choose Location of Built Game", "", "");
        clear(path);
        List<string> levels = new List<string>();

        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            EditorBuildSettingsScene[] s = EditorBuildSettings.scenes;
            levels.Add(s[i].path);
        }

        // 1-й имя вашей игры 2-й формат файла запуска игры
        BuildPipeline.BuildPlayer(levels.ToArray(), path + "/NameApplication" + ".exe", BuildTarget.StandaloneWindows, BuildOptions.None);
        //папка моделей
        if (!File.Exists(path + "/resourses"))
        {
            FileUtil.CopyFileOrDirectory("resourses", path + "/resourses");
        }
        Process proc = new Process();
        proc.StartInfo.FileName = path + "/NameApplication" + ".exe";
        proc.Start();


    }
}