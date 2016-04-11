param($installPath, $toolsPath, $package, $project)

#Copy Ncache Dll's to output dir using postbuildevents
$project.Properties.Item("PostBuildEvent").Value += "`r`nxcopy `"$installPath\additionalLib\net20\*.dll`" `"`$`(ProjectDir`)\bin\$`(ConfigurationName`)\`" /Y /I";

#Include Config
$configItem = $project.ProjectItems.Item("config.ncconf")
#Set Config to CopyAlways
$copyToOutput = $configItem.Properties.Item("CopyToOutputDirectory")
$copyToOutput.Value = 1

$osType =(Get-WmiObject Win32_OperatingSystem).OSArchitecture;
if($osType -eq "64-bit")
{
	$project.Properties.Item("PostBuildEvent").Value += "`r`nxcopy `"$installPath\additionalLib\Oracle20\x64\Oracle.DataAccess.dll`" `"`$`(ProjectDir`)\bin\$`(ConfigurationName`)\`" /Y /I";
}
elseif($osType -eq "32-bit")
{
	$project.Properties.Item("PostBuildEvent").Value += "`r`nxcopy `"$installPath\additionalLib\Oracle20\x32\Oracle.DataAccess.dll`" `"`$`(ProjectDir`)\bin\$`(ConfigurationName`)\`" /Y /I";
}
else
{
	write-host("Error getting OS architecture type.")
}

