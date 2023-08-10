$releaseName = "inizio-application"

# Uninstall the chart
Write-Host "Uninstalling $releaseName chart..."
helm uninstall $releaseName
