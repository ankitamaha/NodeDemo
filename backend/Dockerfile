FROM microsoft/dotnet:latest

# Create app directory
RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app

# Install app dependencies
COPY project.json /usr/src/app/
RUN dotnet restore

# Compile the backend code
RUN dotnet build

# Bundle app source
COPY . /usr/src/app

EXPOSE 5000
CMD [ "dotnet", "run" ]
