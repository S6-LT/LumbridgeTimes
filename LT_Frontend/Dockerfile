FROM node:latest as build

WORKDIR /app

COPY ./ /app/

RUN npm install

RUN npm run dev

EXPOSE 5173

