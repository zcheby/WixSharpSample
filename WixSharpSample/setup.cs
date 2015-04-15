using System;
using System.Linq;
using WixSharp;

public class Script
{
    static public void Main(string[] args)
    {
        // インストール対象を指定する。
        Project project =
            new Project("TargetApplication",
                new Dir(@"%ProgramFiles%\My Company\My Product",
                    new File(@"..\TargetApplication\bin\Release\TargetApplication.exe")));

        // インストール時にフォルダの指定なしにする。
        project.UI = WUI.WixUI_Minimal;
        // バージョンを指定する。
        project.Version = new Version(1, 2, 3, 4);
        // GUIDを指定する。
        project.GUID = new Guid("67c14d17-96f2-488e-a7cc-e4c73e39ee56");
        // 製造者を指定する。
        project.Manufacturer = "SampleManufacturer";

        // インストーラーの言語に日本語を指定する。別途wixui_ja-JP.wxlが必要。
        project.Language = "ja-jp";

        // インストールディレクトリとデスクトップにexeのショートカットを作成する。
        project.FindFile(f => f.Name.EndsWith("TargetApplication.exe"))
       .First()
       .Shortcuts = new[] 
                    {
                        new FileShortcut("TargetApplication.exe", "INSTALLDIR"),
                        new FileShortcut("TargetApplication.exe", "%Desktop%")
                    };
        
        Compiler.BuildMsi(project);
    }
}



