# Death to SQL Server! Long Live SQL Server!

Thanks for checking out my talk about using containerized SQL Server as part of your development process.  Below are some of the commands I ran during the talk:

## Run SQL Server in a Linux container

```
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=DOTnetConf2019!' -p 1433:1433 -v D:/Sources/data:/var/opt/mssql/data --name sql1 -d mcr.microsoft.com/mssql/server:2017-latest
```

### What does it all mean?!?

#### -e 'ACCEPT_EULA=Y'

This flag just accepts the SQL Server EULA.  Nothing to see here.  Move along.

#### -e 'SA_PASSWORD=<YourStrong!Passw0rd>'

Of course, you’ll want to replace `<YourStrong!Passw0rd>` with an actual strong password, but this is just setting that initial password for the sa login.

#### -p 1433:1433

In the format of <Host port>:<Container port>, this maps the containers port to a specific port on the host.  In my case, I mapped 1433 (SQL's default port) to the host 1433.  I could have just as easily mapped it to something else (i.e. `-p 5050:1433`).  The important thing here is that whatever port is used on the host side is the port I'll use in SSMS to connect.  To use a port other than the default, enter the server address in SSMS as `127.0.0.1,<port you chose>`.  Yeah, it's a comma.  Don't ask. :)

#### -v C:/HostPath:/var/opts/mssql/data

Maps a path on the host to a path in the container in the format of <HOST PATH>:<CONTAINER PATH>.  In this instance, any databases created in the container will be accessible as mdf/ldf files on the host in that directory.
You could exclude this parameter and then use `docker cp` to copy files in & out of the container.  However, it’s important to remember that if you have data stored in a container and destroy it, that data is lost.

#### --name sql1

An easy to remember name for the container.  If not specified, you’ll have to reference the container by its id.

#### -d mcr.microsoft.com/mssql/server:2017-latest

Specifies what image to build the container from.

## Copy files in/out of container

```
docker cp ClientGonnaClient.bak sql1:/var/opt/mssql/data/ClientGonnaClient.bak
```

### Say what?

Docker copy takes at least two parameters: source and destination.  The first parameter is the source file, while the second is the destination.  Regardless if the container location is the source or destination it needs to be formatted as: `{container name}:{container path}`.
