FROM node:latest as build
WORKDIR '/app'
COPY ./ /app/
RUN npm install
COPY . .
CMD ["npm", "run", "dev"]
EXPOSE 5173
