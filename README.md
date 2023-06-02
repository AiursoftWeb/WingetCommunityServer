# WingetCommunityServer

[![MIT licensed](https://img.shields.io/badge/license-MIT-blue.svg)](https://gitlab.aiursoft.cn/aiursoft/wingetcommunityserver/-/blob/master/LICENSE)
[![Pipeline stat](https://gitlab.aiursoft.cn/aiursoft/wingetcommunityserver/badges/master/pipeline.svg)](https://gitlab.aiursoft.cn/aiursoft/infrastructures/-/pipelines)
[![Test Coverage](https://gitlab.aiursoft.cn/aiursoft/wingetcommunityserver/badges/master/coverage.svg)](https://gitlab.aiursoft.cn/aiursoft/infrastructures/-/pipelines)

WingetCommunityServer is a self-hosted winget server.

## Run in Ubuntu

First, specify a domain name for your Ubuntu 18.04+, brand-new server.

And execute the following command in the server:

```bash
curl -sL https://gitlab.aiursoft.cn/aiursoft/wingetcommunityserver/-/raw/master/install.sh | sudo bash -s http://wcs.local
```

## Run locally

Requirements about how to run

1. [.NET 6 SDK](http://dot.net/)
2. Execute `dotnet run` to run the app
3. Use your browser to view [http://localhost:5000](http://localhost:5000)

## Run in Microsoft Visual Studio

1. Open the `.sln` file in the project path.
2. Press `F5`.

## How to build locally in docker

Just install docker and docker-compose. Execute the following command.

```bash
docker build -t=wcs .
docker run -d -p 8080:80 wcs
```

That will start a web server at `http://localhost:8080` and you can test the app.

## How to connect with Winget client

First, you need to know the endpoint of your server. For example, `https://localhost:8080/api`.

Then, you need to add the source to your winget client.

```bash
winget source add -n local-server https://localhost:8080/api -t Microsoft.Rest
```

Now you can search and install packages.

```bash
winget search vlc --source local-server
winget install vlc --source local-server
```

### Additional tips

To view the added source:

```bash
winget source list --name local-server
```

You can delete existing system sources via:

```bash
winget source remove winget
winget source remove msstore
```

To reset everything to default:

```bash
winget source reset --force
```

## How to contribute

There are many ways to contribute to the project: logging bugs, submitting pull requests, reporting issues, and creating suggestions.

Even if you with push rights on the repository, you should create a personal fork and create feature branches there when you need them. This keeps the main repository clean and your workflow cruft out of sight.

We're also interested in your feedback on the future of this project. You can submit a suggestion or feature request through the issue tracker. To make this process more effective, we're asking that these include more information to help define them more clearly.