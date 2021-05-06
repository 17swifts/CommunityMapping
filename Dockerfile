###
# @bot-written
#
# WARNING AND NOTICE
# Any access, download, storage, and/or use of this source code is subject to the terms and conditions of the
# Full Software Licence as accepted by you before being granted access to this source code and other materials,
# the terms of which can be accessed on the Codebots website at https://codebots.com/full-software-licence. Any
# commercial use in contravention of the terms of the Full Software Licence may be pursued by Codebots through
# licence termination and further legal action, and be required to indemnify Codebots for any loss or damage,
# including interest and costs. You are deemed to have accepted the terms of the Full Software Licence on any
# access, download, storage, and/or use of this source code.
#
# BOT WARNING
# This file is bot-written.
# Any changes out side of "protected regions" will be lost next time the bot makes any changes.
###

# % protected region % [Customise the build stage] off begin

##### Build Stage #####
###
# SERVERSIDE
###
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-serverside
WORKDIR /build

# Install dotnet EF
RUN dotnet tool install --global dotnet-ef

# Copy and restore project
COPY serverside/src/*.csproj ./
RUN dotnet restore

# Copy & build source
COPY serverside/src ./
RUN export CSHARPBOT_DISABLE_CLIENT_BUILD=1 \
	&& export CSHARPBOT_DISABLE_CLIENT_COPY=1 \
	&& dotnet publish -c Release -o out

###
# CLIENTSIDE
###
FROM node:12-alpine AS build-clientside
WORKDIR /build

# Copy and restore npm/yarn
COPY clientside/package.json ./clientside/yarn.lock* ./
RUN yarn

# Copy & build source
COPY clientside ./
RUN yarn run build
# % protected region % [Customise the build stage] end

# % protected region % [Customise the runtime] off begin
###
# RUNTIME
###
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app

# Copy the built serverside
COPY --from=build-serverside /build/appsettings* ./
COPY --from=build-serverside /build/out ./

# Copy the built clientside
COPY --from=build-clientside /build/build ./Client


ENTRYPOINT ["dotnet", "Cis.dll"]

# % protected region % [Customise the runtime] end
