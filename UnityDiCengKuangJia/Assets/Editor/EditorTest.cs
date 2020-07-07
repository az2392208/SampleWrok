using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorTest : MonoBehaviour
{
    [MenuItem("Tool/打包")]
    public static void Build()
    {
        //                              文件位置                            文件压缩方式,这种是做常用的           这个是文件的平台由于我们可能打包的平台不同 所以可以采用这个动态加载的参数
        BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath, BuildAssetBundleOptions.ChunkBasedCompression, EditorUserBuildSettings.activeBuildTarget);
        AssetDatabase.Refresh();
    }
}
