using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using System;
using System.Collections;
using System.Threading.Tasks;


public static class AddressablesUtil
{
    /// <summary>
    /// アドレスキーが有効かどうか
    /// ※非同期ではないので注意
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static bool Exists(string key)
    {
        return Addressables.LoadAsset<IResourceLocation>(key).Status == AsyncOperationStatus.Succeeded;
    }

    /// <summary>
    /// アドレスキーが有効かどうか
    /// ※非同期
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static async Task<bool> ExistsAsync(string key)
    {
        AsyncOperationHandle<IResourceLocation> handle = Addressables.LoadAssetAsync<IResourceLocation>(key);
        await handle.Task;
        return handle.Status == AsyncOperationStatus.Succeeded;
    }
}
