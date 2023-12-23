FROM node:latest as build
WORKDIR /app
COPY ../
RUN npm install
COPY . .
CMD ["npm", "run", "dev"]
EXPOSE 5173
