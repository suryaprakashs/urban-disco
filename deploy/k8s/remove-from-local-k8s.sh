#!/bin/bash

releaseName="inizio-application"

# Uninstall the chart
echo "Uninstalling $releaseName chart..."
helm uninstall $releaseName
