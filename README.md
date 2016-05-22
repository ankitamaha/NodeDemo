# docker-test-project
Just a sample docker project with separate database, backend API and frontend containers.

This is pretty much just a fun excuse to experiment with dotnet core, node 6 and docker data containers. But if you need more of a reason, imagine you had a pre-existing dotnet API and wanted to migrate to a nodejs platform. This might be a way to do that. Keeping your dotnet API, but hiding it behind your new nodejs app.

Prerequisites
-------------

 - Ubuntu 14.04, you can use the prebuilt docker droplet on digital ocean
 - postgres. I used [Postgres.app](http://postgresapp.com/) and [Postico](https://eggerapps.at/postico/) because they are the easiest way to get postgres installed on your mac.
 - [dotnet core sdk](http://dot.net).
 - [nodejs](http://nodejs.org) v6.x
 - [docker](https://www.docker.com/) (Optional) for deployment (or running locally if you want to run it that way)

You'll also need to create a folder for the postgres image to store the database, so it doesn't get wiped out when we stop the container.

```bash
$ sudo mkdir -p /var/docker/postgresql && chmod 755 /var/docker/postgresql
```

_Special Note:_ If you're using a smaller droplet from digital ocean, you'll probably need to setup a swapfile like I did or the `frontend` container will fail to build because it runs out of memory when it installs the dependencies from npm. [Thankfully, digital ocean has a great guide on setting up a swapfile in Ubuntu 14.04](https://www.digitalocean.com/community/tutorials/how-to-add-swap-on-ubuntu-14-04) which worked perfectly for me!

Infrastructure (Docker)
-----------------------

This project defines 3 containers via the [docker-compose.yml](./docker-compose.yml) file in the root of the project. The containers are named `frontend`, `backend`, and `db`.

`frontend` will contain our nodejs application that is built on top of express and react. It will also act as a proxy for API requests to our `backend` application.

`backend` will contain our asp.net 5 core application that handles all interaction with the postgres database running in the `db` container.

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
