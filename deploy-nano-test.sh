
DOCKER_SERVER=acnichollsacr.azurecr.io
DOCKER_USER=acnichollsacr
DOCKER_PASS=JILPRffBgtUoplLtlbITO3+TKV2dg6SZ


APP_SUBSCRIPTION=c6c2f7e9-efa8-407e-b0ed-0aaa7c61b9c6
APP_SERVICEPLAN=acnichollsasp
APP_RESOURCEGROUP=acnicholls-rg

APP_NAME=psbtPortal


echo "Starting"
echo "Build DB"
# build the db image
docker build -f ./docker/db/Dockerfile.azure -t psbtdb:azure

docker tag psbtdb:azure acnicholls.azurecr.io/psbtdb:azure

docker push acnicholls.azurecr.io/psbtdb:azure
echo "Build Portal"
# build the webserver image
docker build -f ./docker/portal/Dockerfile.azure -t psbtportal:azure .

docker tag psbtportal:azure acnichollsacr.azurecr.io/psbtportal:azure

docker push acnichollsacr.azurecr.io/psbtportal:azure

echo "Done!!"
echo "Now go to the Nano host antlet, copy the compose file and run 'docker-compose -f docker-compose.nano.yml up -d' to run the container from the nano."