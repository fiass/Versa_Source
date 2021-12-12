using System.Reflection;
using MelonLoader;

[assembly: AssemblyTitle(AutoUpdate.BuildInfo.Description)]
[assembly: AssemblyDescription(AutoUpdate.BuildInfo.Description)]
[assembly: AssemblyCompany(AutoUpdate.BuildInfo.Company)]
[assembly: AssemblyProduct(AutoUpdate.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + AutoUpdate.BuildInfo.Author)]
[assembly: AssemblyTrademark(AutoUpdate.BuildInfo.Company)]
[assembly: AssemblyVersion(AutoUpdate.BuildInfo.Version)]
[assembly: AssemblyFileVersion(AutoUpdate.BuildInfo.Version)]
[assembly: MelonInfo(typeof(AutoUpdate.AutoUpdate), AutoUpdate.BuildInfo.Name, AutoUpdate.BuildInfo.Version, AutoUpdate.BuildInfo.Author, AutoUpdate.BuildInfo.DownloadLink)]
[assembly: MelonColor()]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame(null, null)]