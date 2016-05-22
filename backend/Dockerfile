FROM microsoft/dotnet:latest

# Create app directory
RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app

# Install app dependencies
COPY ./App/project.json /usr/src/app/
RUN dotnet restore

# Bundle app source
COPY ./App /usr/src/app

# Compile the backend code
RUN dotnet build

# Migrate the database
RUN dotnet ef database update

EXPOSE 5000
CMD [ "dotnet", "run" ]
