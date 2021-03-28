#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat 

FROM microsoft/aspnet
# The final instruction copies the site you published earlier into the container.
COPY ./bin/app.publish/ /inetpub/wwwroot
