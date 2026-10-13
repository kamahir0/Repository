#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

namespace Lilja.Repository.Setup.Editor
{
    [InitializeOnLoad]
    internal static class SetupDependencies
    {
        private static AddRequest _activeRequest;
        private static string _activePackageName;

#if !LILJA_DEPENDENCY_UNITASK_PRESENT
        [MenuItem("Lilja/Dependencies/Repository/Install UniTask")]
        private static void InstallUniTask()
        {
            InstallPackage("https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask", "UniTask");
        }
#endif

        private static void InstallPackage(string gitUrl, string packageName)
        {
            if (_activeRequest != null && !_activeRequest.IsCompleted)
            {
                Debug.LogWarning($"[Lilja.Repository] Package installation ({_activePackageName}) is already in progress.");
                return;
            }

            _activePackageName = packageName;
            Debug.Log($"[Lilja.Repository] Installing {packageName} from {gitUrl}...");
            _activeRequest = Client.Add(gitUrl);
            EditorApplication.update += MonitorRequest;
        }

        private static void MonitorRequest()
        {
            if (_activeRequest == null || !_activeRequest.IsCompleted)
            {
                return;
            }

            EditorApplication.update -= MonitorRequest;

            if (_activeRequest.Status == StatusCode.Success)
            {
                Debug.Log($"[Lilja.Repository] Successfully installed {_activePackageName} ({_activeRequest.Result.packageId}).");
                AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
            }
            else if (_activeRequest.Status >= StatusCode.Failure)
            {
                Debug.LogError($"[Lilja.Repository] Failed to install {_activePackageName}: {_activeRequest.Error.message}");
            }

            _activeRequest = null;
            _activePackageName = null;
        }
    }
}
#endif
