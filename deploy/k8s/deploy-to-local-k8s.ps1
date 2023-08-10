$chartFolder = "./helm"
$chartVersion = "1.0.0"
$releaseName = "inizio-application"
$namespace = "inizio"
$useDapr = "True"

kubectl apply -f .\redis.yaml
kubectl apply -f .\zipkin.yaml

# Install the chart
Write-Host "Installing chart from $chartFolder..."
helm install $releaseName $chartFolder --version $chartVersion --set namespace=$namespace

if ($useDapr -eq "True") {
    # $redisPasswordEncoded = $(kubectl get secret --namespace default redis -o jsonpath="{.data.redis-password}")
    # $redisPassword = [System.Text.Encoding]::ASCII.GetString([System.Convert]::FromBase64String($redisPasswordEncoded));
    # kubectl create secret generic redis --from-literal=redis-password=$redisPassword --namespace $namespace

    kubectl create secret generic demo-secret --from-literal=demo-secret="Hello from k8s secret store!" --namespace $namespace
    kubectl create secret generic redis --from-literal=redis-password="inizio" --namespace $namespace
}
else {
    kubectl create secret generic secret-appsettings --from-file=./appsettings.json --namespace $namespace
}
