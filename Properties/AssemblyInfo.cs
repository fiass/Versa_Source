using System.Reflection;
using MelonLoader;

[assembly: AssemblyTitle(Versa.BuildInfo.Description)]
[assembly: AssemblyDescription(Versa.BuildInfo.Description)]
[assembly: AssemblyCompany(Versa.BuildInfo.Company)]
[assembly: AssemblyProduct(Versa.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + Versa.BuildInfo.Author)]
[assembly: AssemblyTrademark(Versa.BuildInfo.Company)]
[assembly: AssemblyVersion(Versa.BuildInfo.Version)]
[assembly: AssemblyFileVersion(Versa.BuildInfo.Version)]
[assembly: MelonInfo(typeof(Versa.Main), Versa.BuildInfo.Name, Versa.BuildInfo.Version, Versa.BuildInfo.Author, Versa.BuildInfo.DownloadLink)]
[assembly: MelonColor()]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame(null, null)]