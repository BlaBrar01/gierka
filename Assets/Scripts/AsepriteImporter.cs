using UnityEditor;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class GameObjectInjector : AssetPostprocessor
{
    void OnPreprocessAsset()
    {
        if (assetImporter is AsepriteImporter aseImporter)
            aseImporter.OnPostAsepriteImport += OnPostAsepriteImport;
    }

    static void OnPostAsepriteImport(AsepriteImporter.ImportEventArgs args)
    {
        var myGo = new GameObject("MyGameObject");
        args.context.AddObjectToAsset(myGo.name, myGo);
    }
}