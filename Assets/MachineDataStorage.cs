using System;
using System.IO;

public static class MachineDataStorage
{
    public static string GetStepsStorageFolder(string machineName)
    {
        var meshStorageFolder = Path.Combine(GetMachineStorageFolder(machineName), "Steps");
        EnsureStorageFolderExists(meshStorageFolder);

        return meshStorageFolder;
    }

    public static string GetFieldOfViewStorageFolder(string machineName)
    {
        var meshStorageFolder = Path.Combine(GetMachineStorageFolder(machineName), "FoVs");
        EnsureStorageFolderExists(meshStorageFolder);

        return meshStorageFolder;
    }

    public static string GetMeshStorageFolder(string machineName)
    {
        var meshStorageFolder = Path.Combine(GetMachineStorageFolder(machineName), String.Format("Mesh_{DateTime.Now:yyyy_MM_dd_HH_mm_ss}"));
        EnsureStorageFolderExists(meshStorageFolder);

        return meshStorageFolder;
    }

    public static string GetMachineStorageFolder(string machineName)
    {
        var machineStorageFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "artiso Operations Portal");
        EnsureStorageFolderExists(machineStorageFolder);

        return machineStorageFolder;
    }

    private static void EnsureStorageFolderExists(string machineStorageFolder)
    {
        if (!Directory.Exists(machineStorageFolder))
        {
            Directory.CreateDirectory(machineStorageFolder);
        }
    }
}