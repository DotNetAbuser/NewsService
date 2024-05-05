namespace Shared.Enums;

public enum UploadType : byte
{
    [Description(@"Images\ProfilePictures")]
    ProfilePicture = 1,
    
    [Description(@"Images\NewsPictures")]
    NewsTitlePicture = 2
}