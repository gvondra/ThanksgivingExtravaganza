FROM node:8

ENV NPM_CONFIG_PREFIX=/home/node/.npm-global

# optionally if you want to run npm global bin without specifying path
ENV PATH=$PATH:/home/node/.npm-global/bin 

ENV ENV_STATIC_CONTENT_ROOT="https://thanksgivingextravaganza.blob.core.windows.net/staticcontent"

# Set the working directory to /app
WORKDIR /home/node/app

# Copy the current directory contents into the container at /app
COPY ./package.json /home/node/app
COPY ./server.js /home/node/app
COPY ./config /home/node/app/config

RUN ["npm", "install"]

#RUN ["chown", "-R", "node", "/home/node/app/"]

# Make port 80 available to the world outside this container
EXPOSE 80

# Run index.js when the container launches
CMD ["npm","start"]

USER root