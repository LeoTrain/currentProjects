namespace MyClasses
{
  public static class FileHelper
  {
    public static string ReadFile(string filePath)
    {
      if (!File.Exists(filePath))
        throw new FileNotFoundException($"File {nameof(filePath)} has not been found.");
      return File.ReadAllText(filePath);
    }
    public static void WriteFile(string filePath, string content) => File.WriteAllText(filePath, content);
    public static void AppendToFile(string filePath, string content) => File.AppendAllText(filePath, content);
    public static void DeleteFile(string filePath) { if (File.Exists(filePath)) File.Delete(filePath); }
    public static void FileExists(string filePath) => File.Exists(filePath);
    public static void CopyFile(string sourcePath, string destinationPath, bool overwrite = false) { File.Copy(sourcePath, destinationPath, overwrite); }
    public static void MoveFile(string sourcePath, string destinationPath) { File.Move(sourcePath, destinationPath); }
  }
}
