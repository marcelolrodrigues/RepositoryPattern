FROM mcr.microsoft.com/dotnet/sdk AS build
WORKDIR /

COPY . ./
ADD https://github.com/ufoscout/docker-compose-wait/releases/download/2.8.0/wait /wait
#RUN chmod +x /wait
RUN /bin/bash -c 'ls -la /wait; chmod +x /wait; ls -la /wait'

# install the report generator tool
RUN dotnet tool install dotnet-reportgenerator-globaltool --tool-path /tools

CMD /wait && dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura