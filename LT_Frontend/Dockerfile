FROM node:latest as build

WORKDIR usr/local/app

COPY ./ /usr/local/app/

RUN npm install

RUN npm run dev

EXPOSE 5173

