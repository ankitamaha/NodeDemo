# docker-test-project
Just a sample docker project with separate database, backend API and frontend containers.

This is pretty much just a fun excuse to experiment with dotnet core, node 6 and docker data containers. But if you need more of a reason, imagine you had a pre-existing dotnet API and wanted to migrate to a nodejs platform. This might be a way to do that. Keeping your dotnet API, but hiding it behind your new nodejs app.

Prerequisites
-------------

 - postgres. I used [Postgres.app](http://postgresapp.com/) and [Postico](https://eggerapps.at/postico/) because they are the easiest way to get postgres installed on your mac.
 - [dotnet core sdk](http://dot.net).
 - [nodejs](http://nodejs.org) v6.x
 - [docker](https://www.docker.com/) (Optional) for deployment (or running locally if you want to run it that way)

Infrastructure (Docker)
-----------------------

This project defines 4 containers via the [docker-compose.yml](./docker-compose.yml) file in the root of the project. The containers are named `frontend`, `backend`, `db` and `data`.

`frontend` will contain our nodejs application that is built on top of express and react. It will also act as a proxy for API requests to our `backend` application.

`backend` will contain our asp.net 5 core application that handles all interaction with the postgres database running in the `db` container.

`data` is what is called a "data container" in docker. It only exists to expose a volume of data to another container. Data containers allow us to upgrade our database container without fear of wiping our database data.

![https://docs.google.com/drawings/d/199Ym5d6jrl4_4IOGT1boWgSAMdis8w1diVqc-YT-2IE/pub?w=791&h=772](https://docs.google.com/drawings/d/199Ym5d6jrl4_4IOGT1boWgSAMdis8w1diVqc-YT-2IE/pub?w=791&h=772)

### DNS Configuration

The docker configuration for this project only allows certain containers to communicate. This is done via the `ports` and `links` sections of the docker-compose file.

`frontend` can only see `backend` and `backend` can only see `db`. `frontend` is the only container exposed to the host machine, and it is also exposed to the outside via port `8000`.

## Running The Backend (in development)

```bash
$ cd backend/App
$ dotnet restore && dotnet build
$ cd ../Test
$ dotnet restore && dotnet test
```

## Running The Frontend (in development)

```bash
$ cd frontend
$ npm install && npm run build && npm start
```
