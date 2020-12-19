#!/bin/bash

cd /app

set -e
run_cmd="dotnet /app/bin/RELEASE/netcoreapp3.1/ProjectSourceBackupToolPortal.dll"
# run_cmd="find / -name ProjectSourceBackupToolPortal.dll"

until dotnet ef database update; do
>&2 echo "SQL Server is starting up"
sleep 5
done

>&2 echo "SQL Server is up - executing command"
exec $run_cmd

