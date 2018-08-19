FROM node:8

ENV NPM_CONFIG_PREFIX=/home/node/.npm-global

# optionally if you want to run npm global bin without specifying path
ENV PATH=$PATH:/home/node/.npm-global/bin 

# Set the working directory to /app
WORKDIR /home/node/app

# Copy the current directory contents into the container at /app
ADD ./package.json /home/node/app
ADD ./server.js /home/node/app
ADD ./dist /home/node/app/dist

RUN ["npm", "install"]

# Make port 3000 available to the world outside this container
EXPOSE 3000

# Run index.js when the container launches
CMD ["npm","start"]

USER node