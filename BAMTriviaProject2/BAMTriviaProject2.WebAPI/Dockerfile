# multi-stage build - FROM command can name a stage.

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build

WORKDIR /app

# take advantage of docker layer caching...
# these two layers will be cached so long as the csproj file(s) does not change.
COPY ./*.csproj ./
RUN dotnet restore

# if i just change a .cs file, then i can use that cache and the next line will
# be the first one to actually run.

COPY . ./

# build & publish to /app/out
RUN dotnet build --no-restore

RUN dotnet test

RUN dotnet publish --no-restore -c Release -o out

# docker allows us to use some layers just temporarily
# and then copy certain files out of them onto a new base image.
# this means the resulting final image will be smaller.

# asp.net core runtime image. (much smaller than sdk!)
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime

WORKDIR /app

# copy from a previous stage, instead of from outside Docker
COPY --from=build /app/out ./

# set environment variable inside image
# asp.net core looks at this when seeing what port to put itself on
# ENV ASPNETCORE_URLS=http://*:5050
# EXPOSE by itself, does nothing -- but hints to the guy running the container from this
# image, that he should bind 5050 to something.
# EXPOSE 5050

# there is technical difference between CMD and ENTRYPOINT

ENTRYPOINT [ "dotnet", "BAMTriviaProject2.WebAPI.dll" ]

# best of both worlds from multi-stage build:
# repeatable build environment, plus small image size

# (add comment to change Dockerfile)
