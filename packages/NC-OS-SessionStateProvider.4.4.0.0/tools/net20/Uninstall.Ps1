param($installPath, $toolsPath, $package, $project)

$project.Object.References | Where-Object { $_.Name -eq 'Alachisoft.NCache.Cache' } | ForEach-Object { $_.Remove() }
$project.Object.References | Where-Object { $_.Name -eq 'Alachisoft.NCache.Common' } | ForEach-Object { $_.Remove() }
$project.Object.References | Where-Object { $_.Name -eq 'Alachisoft.NCache.Management' } | ForEach-Object { $_.Remove() }
$project.Object.References | Where-Object { $_.Name -eq 'Alachisoft.NCache.Runtime' } | ForEach-Object { $_.Remove() }
$project.Object.References | Where-Object { $_.Name -eq 'Alachisoft.NCache.Security' } | ForEach-Object { $_.Remove() }
$project.Object.References | Where-Object { $_.Name -eq 'Alachisoft.NCache.Serialization' } | ForEach-Object { $_.Remove() }
$project.Object.References | Where-Object { $_.Name -eq 'Alachisoft.NCache.Web' } | ForEach-Object { $_.Remove() }
$project.Object.References | Where-Object { $_.Name -eq 'Alachisoft.NCache.SessionStateManagement' } | ForEach-Object { $_.Remove() }
$project.Object.References | Where-Object { $_.Name -eq 'Alachisoft.NCache.SessionStoreProvider' } | ForEach-Object { $_.Remove() }
