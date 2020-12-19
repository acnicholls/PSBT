
DOCKER_SERVER=acnichollsacr.azurecr.io
DOCKER_USER=acnichollsacr
DOCKER_PASS=JILPRffBgtUoplLtlbITO3+TKV2dg6SZ


APP_SUBSCRIPTION=c6c2f7e9-efa8-407e-b0ed-0aaa7c61b9c6
APP_SERVICEPLAN=acnichollsasp
APP_RESOURCEGROUP=acnicholls-rg

APP_NAME=psbtPortal

# build the db image
docker build -f ./docker/db/Dockerfile.azure -t psbtdb:azure

docker tag psbtdb:azure acnicholls.azurecr.io/psbtdb:azure

docker push acnicholls.azurecr.io/psbtdb:azure

# build the webserver image
docker build -f ./docker/portal/Dockerfile.azure -t psbtportal:azure .

docker tag psbtportal:azure acnichollsacr.azurecr.io/psbtportal:azure

docker push acnichollsacr.azurecr.io/psbtportal:azure

# give the script time to finish the upload?
sleep 10 

if (az webapp list | grep $APP_NAME)
then
    # the service exists, so just "reconfigure"
    az webapp config container set \
        --subscription=$APP_SUBSCRIPTION \
        --resource-group=$APP_RESOURCEGROUP \
        --name=$APP_NAME \
        --docker-registry-server-url=$DOCKER_SERVER \
        --docker-registry-server-user=$DOCKER_USER \
        --docker-registry-server-password=$DOCKER_PASS \
        --enable-app-service-storage \
        --multicontainer-config-type=COMPOSE \
        --multicontainer-config-file=docker-compose.staging.yml

    az webapp log config \
        --subscription=$APP_SUBSCRIPTION \
        --resource-group=$APP_RESOURCEGROUP \
        --name=$APP_NAME \
        --application-logging=filesystem \
        --web-server-logging=filesystem \ 
        --level=verbose

    az webapp restart \
        --subscription=$APP_SUBSCRIPTION \
        --resource-group=$APP_RESOURCEGROUP \
        --name=$APP_NAME \


else
    # create a new service
    az webapp create \
        --subscription=$APP_SUBSCRIPTION \
        --resource-group=$APP_RESOURCEGROUP \
        --name=$APP_NAME \
        --plan=$APP_SERVICEPLAN \
        --deployment-source-url=$DOCKER_SERVER \
        --docker-registry-user=$DOCKER_USER \
        --docker-registry-server-password=$DOCKER_PASS \  
        --multicontainer-config-type=COMPOSE \
        --multicontainer-config-file=docker-compose.staging.yml      

    az webapp config container set \
        --subscription=$APP_SUBSCRIPTION \
        --resource-group=$APP_RESOURCEGROUP \
        --name=$APP_NAME \
        --docker-registry-server-url=$DOCKER_SERVER \
        --docker-registry-server-user=$DOCKER_USER \
        --docker-registry-server-password=$DOCKER_PASS \
        --enable-app-service-storage \
        --multicontainer-config-type=COMPOSE \
        --multicontainer-config-file=docker-compose.staging.yml

    az webapp log config \
        --subscription=$APP_SUBSCRIPTION \
        --resource-group=$APP_RESOURCEGROUP \
        --name=$APP_NAME \
        --application-logging=filesystem \
        --web-server-logging=filesystem \ 
        --level=verbose
fi
