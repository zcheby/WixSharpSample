using System;
using System.Linq;
using WixSharp;

public class Script
{
    static public void Main(string[] args)
    {
        // �C���X�g�[���Ώۂ��w�肷��B
        Project project =
            new Project("TargetApplication",
                new Dir(@"%ProgramFiles%\My Company\My Product",
                    new File(@"..\TargetApplication\bin\Release\TargetApplication.exe")));

        // �C���X�g�[�����Ƀt�H���_�̎w��Ȃ��ɂ���B
        project.UI = WUI.WixUI_Minimal;
        // �o�[�W�������w�肷��B
        project.Version = new Version(1, 2, 3, 4);
        // GUID���w�肷��B
        project.GUID = new Guid("67c14d17-96f2-488e-a7cc-e4c73e39ee56");
        // �����҂��w�肷��B
        project.Manufacturer = "SampleManufacturer";

        // �C���X�g�[���[�̌���ɓ��{����w�肷��B�ʓrwixui_ja-JP.wxl���K�v�B
        project.Language = "ja-jp";

        // �C���X�g�[���f�B���N�g���ƃf�X�N�g�b�v��exe�̃V���[�g�J�b�g���쐬����B
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



