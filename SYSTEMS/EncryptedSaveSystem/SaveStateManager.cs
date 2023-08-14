using System.IO;
using UnityEngine;

public class SaveStateManager : MonoBehaviour
{
    private const string mainSaveFileName = "save.dat";
    private const string backupSaveFileName = "save.bak";
    

    public void SaveGame()
    {
        // Gather data from game components, e.g.:
        PlayerSaveData playerData = new PlayerSaveData { /* populate data here */ };
        GameProgressSaveData gameProgressData = new GameProgressSaveData { /* populate data here */ };

        string saveString = JsonUtility.ToJson(new { Player = playerData, GameProgress = gameProgressData });
        string encryptedSave = EncryptionUtility.Encrypt(saveString);

        // Backup the old save file (if it exists) before writing the new one
        if (File.Exists(mainSaveFileName))
        {
            File.Copy(mainSaveFileName, backupSaveFileName, true);
        }

        File.WriteAllText(mainSaveFileName, encryptedSave);
    }

    public void LoadGame()
    {
        if (File.Exists(mainSaveFileName))
        {
            string encryptedData = File.ReadAllText(mainSaveFileName);
            string decryptedData = EncryptionUtility.Decrypt(encryptedData);
            var saveData = JsonUtility.FromJson(decryptedData, typeof(object));

            // Parse and apply the data to your game components
            // For instance: 
            // PlayerSaveData playerData = JsonUtility.FromJson<PlayerSaveData>(saveData.Player.ToString());
        }
        else
        {
            Debug.LogWarning("Save file not found!");
        }
    }

    /// <summary>
    /// Deletes the main save file.
    /// </summary>
    public void DeleteSave()
    {
        if (File.Exists(mainSaveFileName))
        {
            File.Delete(mainSaveFileName);
        }
        else
        {
            Debug.LogWarning("Main save file not found!");
        }
    }

    /// <summary>
    /// Deletes the backup save file.
    /// </summary>
    public void DeleteBackup()
    {
        if (File.Exists(backupSaveFileName))
        {
            File.Delete(backupSaveFileName);
        }
        else
        {
            Debug.LogWarning("Backup save file not found!");
        }
    }

    /// <summary>
    /// Restores the game from the backup save file.
    /// </summary>
    public void LoadBackup()
    {
        if (File.Exists(backupSaveFileName))
        {
            string encryptedData = File.ReadAllText(backupSaveFileName);
            string decryptedData = EncryptionUtility.Decrypt(encryptedData);
            var saveData = JsonUtility.FromJson(decryptedData, typeof(object));

            // Parse and apply the data to your game components
            // For example: 
            // PlayerSaveData playerData = JsonUtility.FromJson<PlayerSaveData>(saveData.Player.ToString());
        }
        else
        {
            Debug.LogWarning("Backup save file not found!");
        }
    }

    /// <summary>
    /// Checks if the main save file exists.
    /// </summary>
    public bool MainSaveExists()
    {
        return File.Exists(mainSaveFileName);
    }

    /// <summary>
    /// Checks if the backup save file exists.
    /// </summary>
    public bool BackupSaveExists()
    {
        return File.Exists(backupSaveFileName);
    }
}