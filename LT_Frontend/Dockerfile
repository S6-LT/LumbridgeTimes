FROM node:latest as build
WORKDIR /app
COPY . .
RUN npm install nodemon -g
EXPOSE 5173
CMD ["npm", "run", "dev"]
