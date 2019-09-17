## Run the project by running it directly in VS and then running in the docker linux container
## Just click the "Get Spreadsheet" button, which webapp will show how many sheets there are in the spreadsheet (the spreadsheet is in the Data directory)

# Visual Studio
### Open the project and run through Visual Studio

# Docker
## Create docker image
### In the root directory run the following command
docker build -t workbooktest .

## Execute docker container
### In the root directory run the following command
docker run --rm -it -p 8000:80 -p 8001:443 -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORT=8001 -e ASPNETCORE_Kestrel__Certificates__Default__Password="crypticpassword" -e ASPNETCORE_Kestrel__Certificates__Default__Path=aspnetapp.pfx workbooktest