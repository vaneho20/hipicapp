param($installPath, $toolsPath, $package, $project)

$project.Object.References | Where-Object { $_.Name -eq 'Alachisoft.NCache.Integrations.NHibernate.Cache' } | ForEach-Object { $_.Remove() }