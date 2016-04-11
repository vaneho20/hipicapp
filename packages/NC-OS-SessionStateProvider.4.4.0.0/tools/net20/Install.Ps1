param($installPath, $toolsPath, $package, $project)

if (Test-Path Env:\nchome)
{
	$project.Object.References.Add("$env:NCHOME\bin\assembly\2.0\Alachisoft.NCache.Cache.dll");
	$project.Object.References.Add("$env:NCHOME\bin\assembly\2.0\Alachisoft.NCache.Common.dll");
	$project.Object.References.Add("$env:NCHOME\bin\assembly\2.0\Alachisoft.NCache.Management.dll");
	$project.Object.References.Add("$env:NCHOME\bin\assembly\2.0\Alachisoft.NCache.Runtime.dll");	
	$project.Object.References.Add("$env:NCHOME\bin\assembly\2.0\Alachisoft.NCache.Security.dll");
	$project.Object.References.Add("$env:NCHOME\bin\assembly\2.0\Alachisoft.NCache.Serialization.dll");
	$project.Object.References.Add("$env:NCHOME\bin\assembly\2.0\Alachisoft.NCache.Web.dll");
	
	$project.Object.References.Add("$env:NCHOME\bin\assembly\2.0\Alachisoft.NCache.SessionStateManagement.dll");
	$project.Object.References.Add("$env:NCHOME\bin\assembly\2.0\Alachisoft.NCache.SessionStoreProvider.dll");
	
	foreach ($reference in $project.Object.References)
	{
		if($reference.Name -Match "Alachisoft*")
		{
			if($reference.CopyLocal -eq $false)
			{
				$reference.CopyLocal = $true;
			}
		}
	}
}
else
{
	echo "NCache is not installed on this system."
}