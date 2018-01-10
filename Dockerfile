FROM mono:onbuild

RUN curl https://api.nuget.org/downloads/nuget.exe -o nuget.exe
RUN mono nuget.exe update -self
RUN mono nuget.exe install NUnit
RUN mono nuget.exe install NUnit.Runners
