FROM microsoft/dotnet:latest

# Create app directory
RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app

# Install app dependencies
COPY project.json /usr/src/app/

# run with a timeout, dotnet restore has hung for me in docker run
RUN timeout 60 dotnet restore

# Bundle app source
COPY . /usr/src/app

EXPOSE 5000
CMD [ "dotnet", "run" ]
