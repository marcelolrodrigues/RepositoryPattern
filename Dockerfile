FROM mcr.microsoft.com/dotnet/sdk AS build
WORKDIR /

# configuring proxy
#ENV http_proxy http://proxy.prodest.es.gov.br.local:8082
#ENV https_proxy http://proxy.prodest.es.gov.br.local:8082

COPY . ./
ADD https://github.com/ufoscout/docker-compose-wait/releases/download/2.8.0/wait /wait
#RUN chmod +x /wait
RUN /bin/bash -c 'ls -la /wait; chmod +x /wait; ls -la /wait'

# install the report generator tool
RUN dotnet tool install dotnet-reportgenerator-globaltool --tool-path /tools

CMD /wait && dotnet test Repository/tests/SpecificationPatternRepository.Core.UnitTests/SpecificationPatternRepository.Core.UnitTests.csproj --logger trx --results-directory /var/temp /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura && mv Repository/tests/SpecificationPatternRepository.Core.UnitTests/coverage.cobertura.xml /var/temp/coverage.unit.cobertura.xml && dotnet test Repository/tests/SpecificationPatternRepository.Infrastructure.IntegrationTests/SpecificationPatternRepository.Core.UnitTests.csproj --logger trx --results-directory /var/temp /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura && mv Repository/tests/SpecificationPatternRepository.Infrastructure.IntegrationTests/coverage.cobertura.xml /var/temp/coverage.ef.integration.cobertura.xml && tools/reportgenerator -reports:/var/temp/coverage.*.cobertura.xml -targetdir:/var/temp/coverage -reporttypes:HtmlInline_AzurePipelines\;HTMLChart\;Cobertura