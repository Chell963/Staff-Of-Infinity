using System.Threading.Tasks;
using Implementations;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Controllers
{
    public class AssetController : Controller
    {
        public static async Task<T> LoadAssetAsync<T>(AssetReference reference, Transform parent = null)
        {
            var assetDownloaded = false;
            T newAsset = default;
            if (parent != null)
            {
                Addressables.InstantiateAsync(reference, parent).Completed += handle =>
                {
                    if (handle.Result.TryGetComponent<T>(out var asset))
                    {
                        newAsset = asset;
                        assetDownloaded = true;
                    }
                };
            }
            else
            {
                Addressables.LoadAssetAsync<T>(reference).Completed += handle =>
                {
                    newAsset = handle.Result;
                    assetDownloaded = true;
                };
            }
            while (!assetDownloaded)
            {
                await Task.Yield();
            }
            return newAsset;
        }
        
        public static bool AddressableResourceExists(object key) 
        {
            foreach (var locator in Addressables.ResourceLocators) 
            {
                if (locator.Locate(key, key.GetType(), out var locs))
                    return true;
            }
            return false;
        }
    }
}
