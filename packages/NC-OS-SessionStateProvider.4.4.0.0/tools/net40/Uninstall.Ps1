param($installPath, $toolsPath, $package, $project)

$project.Object.References | Where-Object { $_.Name -eq 'Alachisoft.NCache.SessionStateManagement' } | ForEach-Object { $_.Remove() }
$project.Object.References | Where-Object { $_.Name -eq 'Alachisoft.NCache.SessionStoreProvider' } | ForEach-Object { $_.Remove() }
