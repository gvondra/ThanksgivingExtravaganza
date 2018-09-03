FROM node:8

ENV NPM_CONFIG_PREFIX=/home/node/.npm-global

# optionally if you want to run npm global bin without specifying path
ENV PATH=$PATH:/home/node/.npm-global/bin 

# Set the working directory to /app
WORKDIR /home/node/app

# Copy the current directory contents into the container at /app
ADD ./package.json /home/node/app
ADD ./server.js /home/node/app
ADD ./config /home/node/app/config

RUN ["npm", "install"]

ENV ENV_STATIC_CONTENT_ROOT="https://thanksgivingextravaganza.blob.core.windows.net/staticcontent/"

# Make port 8080 available to the world outside this container
EXPOSE 8080

# Run index.js when the container launches
CMD ["npm","start"]

USER node