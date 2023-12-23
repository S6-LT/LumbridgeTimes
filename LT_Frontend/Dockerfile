FROM node:latest as build
WORKDIR /app
RUN ls -al 
COPY package*.json ./
RUN ls -al 
RUN npm install
COPY . .
EXPOSE 5173
CMD ["npm", "run", "dev"]
