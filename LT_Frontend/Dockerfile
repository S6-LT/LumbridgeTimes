FROM node:latest as build
WORKDIR '/src'
COPY src .
RUN npm install
COPY . .
EXPOSE 5173
CMD ["npm", "run", "dev"]
