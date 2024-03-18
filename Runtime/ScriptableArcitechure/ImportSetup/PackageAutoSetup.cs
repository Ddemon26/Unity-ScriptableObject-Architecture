using UnityEditor;
using System.IO;
using UnityEngine;

[InitializeOnLoad]
public class PackageAutoSetup
{
    static PackageAutoSetup()
    {
        // Path to the resources in the package.
        string packageResourcesPath = "Packages/Unity-ScriptableObject-Architecture/Resources";

        // Path to the Resources folder in the Assets directory.
        string targetResourcesPath = "Assets/Resources";

        // Check if the package resources folder exists.
        if (Directory.Exists(packageResourcesPath))
        {
            // Ensure the target Resources folder exists.
            if (!Directory.Exists(targetResourcesPath))
            {
                Directory.CreateDirectory(targetResourcesPath);
            }

            // Copy all files from the package resources folder to the target Resources folder.
            foreach (string file in Directory.GetFiles(packageResourcesPath))
            {
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(targetResourcesPath, fileName);

                // Only copy the file if it doesn't already exist in the target folder.
                if (!File.Exists(destFile))
                {
                    // Check if the file is a script.
                    if (Path.GetExtension(file) != ".cs")
                    {
                        File.Copy(file, destFile);
                    }
                }
            }

            // Refresh the AssetDatabase to update the Unity Editor.
            AssetDatabase.Refresh();
        }
        else
        {
            // The package resources folder doesn't exist, so remove the Resources folder if it's empty.
            if (Directory.Exists(targetResourcesPath) && Directory.GetFiles(targetResourcesPath).Length == 0)
            {
                Directory.Delete(targetResourcesPath);
                AssetDatabase.Refresh();
            }
        }
    }
}