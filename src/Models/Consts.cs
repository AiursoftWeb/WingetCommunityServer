namespace WingetCommunityServer.Models;

public class Consts
{
    public const string CommonType = $"WingetCommunityServer.Entity, {ServerName}";

    public const string ServerName = "Local-Winget-REST-Server";

    public const string FakePackageName = "VLC";

    public const string FakePackagePublisher = "VideoLAN";

    public const string FakePackageIdentifier = $"{FakePackagePublisher}.{FakePackageName}";

    public const string FakePackageVersion = "99.9.9-fake";

    public const string FakePackageInstallType = "wix";

    public const string FakePackageInstallUrl = "https://download.videolan.org/vlc/3.0.18/win64/vlc-3.0.18-win64.msi";

    public const string FakePackageInstallSha256 = "a618d66b2f753343402200ad17d92eb6d4ab10db0dd1a098402e2968aa3114c4";
}
